using CodeStage.AntiCheat.Detectors;
using DetectCheat;
using HarmonyLib;

namespace InternalCheat.Patches.AntiCheat;

public class AntiCheatToolkitPatches
{
    [HarmonyPatch(typeof(MemoryTamperingDetection), "Start")]
    [HarmonyPrefix]
    static bool MemoryTamperingDetectPatch()
    {
        return false;
    }

    [HarmonyPatch(typeof(InjectionDetector), "StartDetectionInternal")]
    [HarmonyPrefix]
    static bool InjectionDetectPatch(InjectionDetector __instance, ref InjectionDetector __result)
    {
        InjectionDetector.StopDetection();
        __result = __instance;
        return false;
    }

    [HarmonyPatch(typeof(ObscuredCheatingDetector), "StartDetectionInternal")]
    [HarmonyPrefix]
    static bool ObscuredCheatingDetectPatch(ObscuredCheatingDetector __instance, ref ObscuredCheatingDetector __result)
    {
        ObscuredCheatingDetector.StopDetection();
        __result = __instance;
        return false;
    }

    [HarmonyPatch(typeof(SpeedHackDetector), "StartDetectionInternal")]
    [HarmonyPrefix]
    static bool SpeedHackDetectPatch(SpeedHackDetector __instance, ref SpeedHackDetector __result)
    {
        SpeedHackDetector.StopDetection();
        __result = __instance;
        return false;
    }

    [HarmonyPatch(typeof(TimeCheatingDetector), "StartDetectionInternal")]
    [HarmonyPrefix]
    static bool TimeCheatingDetectPatch(TimeCheatingDetector __instance, ref TimeCheatingDetector __result)
    {
        TimeCheatingDetector.StopDetection();
        __result = __instance;
        return false;
    }

    [HarmonyPatch(typeof(WallHackDetector), "StartDetectionInternal")]
    [HarmonyPrefix]
    static bool WallHackDetectPatch(WallHackDetector __instance, ref WallHackDetector __result)
    {
        WallHackDetector.StopDetection();
        __result = __instance;
        return false;
    }
}