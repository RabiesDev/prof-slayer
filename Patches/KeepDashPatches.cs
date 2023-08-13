using HarmonyLib;

namespace InternalCheat.Patches;

public class KeepDashPatches
{
    [HarmonyPatch(typeof(HipShotState), "CanDash", MethodType.Getter)]
    [HarmonyPatch(typeof(ADSState), "CanDash", MethodType.Getter)]
    [HarmonyPatch(typeof(BugBombActionState), "CanDash", MethodType.Getter)]
    [HarmonyPatch(typeof(ButterflyGrenadeState), "CanDash", MethodType.Getter)]
    [HarmonyPatch(typeof(ClimbActionState), "CanDash", MethodType.Getter)]
    [HarmonyPatch(typeof(DeadActionState), "CanDash", MethodType.Getter)]
    [HarmonyPatch(typeof(FurnitureActionState), "CanDash", MethodType.Getter)]
    [HarmonyPatch(typeof(HackingActionState), "CanDash", MethodType.Getter)]
    [HarmonyPatch(typeof(ReloadState), "CanDash", MethodType.Getter)]
    [HarmonyPatch(typeof(WarpState), "CanDash", MethodType.Getter)]
    [HarmonyPrefix]
    static bool CanDashPatch(ref bool __result)
    {
        __result = true;
        return false;
    }
}