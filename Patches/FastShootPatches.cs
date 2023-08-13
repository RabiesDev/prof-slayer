using System;
using HarmonyLib;

namespace InternalCheat.Patches;

public class FastShootPatches
{
    [HarmonyPatch(typeof(PlayerFireManager), "Fire", typeof(bool), typeof(GunConfiguration))]
    [HarmonyReversePatch]
    public static void Fire(object instance, bool isADS, GunConfiguration gunConfig)
    {
        // its a stub so it has no initial content
        throw new NotImplementedException("It's a stub");
    }

    [HarmonyPatch(typeof(PlayerFireManager), "FireRequest", typeof(GunConfiguration))]
    [HarmonyPrefix]
    static bool FireRequestPatch(PlayerFireManager __instance, object[] __args, ref IPlayerControlInfo ___m_PlayerControlInfo)
    {
        if (!MainPlugin.IsActivated("Fast Shoot"))
        {
            return true;
        }

        Fire(__instance, ___m_PlayerControlInfo.IsADS, (GunConfiguration)__args[0]);
        return false;
    }

    [HarmonyPatch(typeof(HipShotState), "Update", typeof(PlayerStateContext))]
    [HarmonyPrefix]
    static bool UpdatePatch(object[] __args, ref IPlayerActionState __result, GunConfiguration ___m_GunConfig)
    {
        if (!MainPlugin.IsActivated(""))
        {
            return true;
        }

        PlayerStateContext context = (PlayerStateContext)__args[0];
        context.PlayerViewPointController.RequestMoveViewPointOnFrame();
        PlayerActionStateHelper.UpdateSelectMarker(context);

        if (Singleton.InputManager.GetADSKey())
        {
            __result = new ADSState();
            return false;
        }

        if (Singleton.InputManager.GetKey(Key.Fire))
        {
            context.PlayerFireManager.FireRequest(___m_GunConfig);
            __result = null;
            return false;
        }

        __result = new AimState();
        return false;
    }
}