using HarmonyLib;

namespace InternalCheat.Patches;

public class AirJumpPatches
{
    [HarmonyPatch(typeof(PlayerLocomotion), "IsGrounded", MethodType.Getter)]
    [HarmonyPrefix]
    static bool IsGroundedPatch(ref bool __result)
    {
        if (!MainPlugin.IsActivated("Air Jump"))
        {
            return true;
        }

        __result = true;
        return false;
    }
}