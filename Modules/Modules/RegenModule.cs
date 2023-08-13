using UnityEngine;

namespace InternalCheat.Modules.Modules;

public class RegenModule : BaseModule
{
    public RegenModule() : base("Regen", ModuleType.Toggle)
    {
    }

    public override void OnUpdate()
    {
        if (!IsInstanced)
        {
            return;
        }

        if (!PlayerEntityRepository.Instance.TryGetLocalPlayer(out var localPlayer) || localPlayer.Context.Hp >= localPlayer.Context.MaxHp)
        {
            return;
        }

        var actorNumber = localPlayer.Context.ActorNumber;
        var difference = Mathf.Clamp(localPlayer.Context.MaxHp - localPlayer.Context.Hp, 0, localPlayer.Context.MaxHp);
        GamePlayerStatusRPCDispatcher.Instance.AddDamage(actorNumber, actorNumber, -difference, Vector3.zero, GamePlayerStatusRPCDispatcher.DamageType.Melee, false);
    }
}