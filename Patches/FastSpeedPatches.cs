using HarmonyLib;

namespace InternalCheat.Patches;

public class FastSpeedPatches
{
    [HarmonyPatch(typeof(PlayerStateExtensions), "GetMoveSpeed", typeof(PlayerBaseState), typeof(PlayerActionState))]
    [HarmonyPrefix]
    static bool MoveSpeedPatch(object[] __args, ref float __result)
    {
        if (!MainPlugin.IsActivated("Fast Speed"))
        {
            return true;
        }

        if ((PlayerActionState)__args[1] == PlayerActionState.DroneAction)
        {
            __result = 0.0f;
            return false;
        }

        var baseState = (PlayerBaseState)__args[0];
        __result = baseState == PlayerBaseState.Dash ? GeneralSettings.Shared.MoveParameter.m_DashSpeed * 2.5f : GeneralSettings.Shared.MoveParameter.m_DashSpeed;
        return false;
    }
}