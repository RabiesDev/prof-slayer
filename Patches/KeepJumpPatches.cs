using HarmonyLib;

namespace InternalCheat.Patches;

public class KeepJumpPatches
{
    [HarmonyPatch(typeof(HipShotState), "CanJump", MethodType.Getter)]
    [HarmonyPatch(typeof(ADSState), "CanJump", MethodType.Getter)]
    [HarmonyPatch(typeof(BugBombActionState), "CanJump", MethodType.Getter)]
    [HarmonyPatch(typeof(ButterflyGrenadeState), "CanJump", MethodType.Getter)]
    [HarmonyPatch(typeof(ClimbActionState), "CanJump", MethodType.Getter)]
    [HarmonyPatch(typeof(DeadActionState), "CanJump", MethodType.Getter)]
    [HarmonyPatch(typeof(FurnitureActionState), "CanJump", MethodType.Getter)]
    [HarmonyPatch(typeof(HackingActionState), "CanJump", MethodType.Getter)]
    [HarmonyPatch(typeof(ReloadState), "CanJump", MethodType.Getter)]
    [HarmonyPatch(typeof(WarpState), "CanJump", MethodType.Getter)]
    [HarmonyPrefix]
    static bool CanJumpPatch(ref bool __result)
    {
        __result = true;
        return false;
    }
}