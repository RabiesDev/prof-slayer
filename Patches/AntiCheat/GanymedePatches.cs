using Cysharp.Threading.Tasks;
using Ganymede.CheatDetection.ObservationPlayer;
using HarmonyLib;

namespace InternalCheat.Patches.AntiCheat;

public class GanymedePatches
{
    [HarmonyPatch(typeof(FastShootingCheatDetector), "SetFireLog", typeof(int), typeof(Equipment.GunType))]
    [HarmonyPrefix]
    static bool FastShootingCheatDetectPatch()
    {
        return false;
    }

    [HarmonyPatch(typeof(HighSpeedCheatDetector), "Start")]
    [HarmonyPrefix]
    static bool HighSpeedCheatDetectPatch(ref UniTaskVoid __result)
    {
        __result = new UniTaskVoid();
        return false;
    }

    [HarmonyPatch(typeof(PlayerHpIncreaseDetector), "Start")]
    [HarmonyPrefix]
    static bool PlayerHpIncreaseDetectPatch(ref UniTaskVoid __result)
    {
        __result = new UniTaskVoid();
        return false;
    }
}