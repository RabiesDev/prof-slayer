using Ganymede.FX;
using HarmonyLib;
using UnityEngine;

namespace InternalCheat.Patches;

public class TeamKillPatches
{
    [HarmonyPatch(typeof(PlayerAttackHittable), "OnHitGunshot", typeof(PlayerContext), typeof(GunConfiguration), typeof(Vector3), typeof(RaycastHit))]
    [HarmonyPrefix]
    static bool HitGunshotPatch(object[] __args, ref bool __result, PlayerContext ___m_PlayerContext)
    {
        var attacker = (PlayerContext)__args[0];
        var gun = (GunConfiguration)__args[1];
        var origin = (Vector3)__args[2];
        var hitInfo = (RaycastHit)__args[3];

        var vector3 = hitInfo.point - origin;
        var normalized = vector3.normalized;
        var isHeadShot = hitInfo.collider.gameObject.GetComponent<HeadshotTarget>() != null;
        var damage = gun.Parameter.m_Damage;
        if (isHeadShot)
        {
            damage *= gun.Parameter.m_HeadShotMagnification;
        }

        if (attacker.IsMe)
        {
            Singleton.GameSystem.AntiCheatPlayerObserverCompositor.PlayerHpObserver.OnHit(___m_PlayerContext.ActorNumber, isHeadShot, damage);
            GamePlayerStatusRPCDispatcher.Instance.AddDamage(___m_PlayerContext.ActorNumber, attacker.ActorNumber,damage, normalized, gun.Parameter.m_DamageType, isHeadShot);
        }

        if (attacker.IsViewed)
        {
            Singleton.GameSystem.HUD.ShowHitReticleEffect();
            if (isHeadShot)
            {
                GeneralSettings.Shared.Sounds.m_GiveHeadDamageSound.Random().Play();
            }
            else
            {
                GeneralSettings.Shared.Sounds.m_GiveDamageSound.Random().Play();
            }
        }

        if (___m_PlayerContext.ActorNumber != attacker.ActorNumber)
        {
            var gameObject = ___m_PlayerContext.ThirdPersonCharacter.gameObject;
            vector3 = hitInfo.point;
            ref var local1 = ref vector3;
            ref var local2 = ref origin;
            GunshotHitEffect.Play(gameObject, in local1, in local2);
        }

        __result = true;
        return false;
    }
}