using System.Threading.Tasks;
using Ganymede.CheatDetection.EasyAntiCheat;
using HarmonyLib;

namespace InternalCheat.Patches.AntiCheat;

public class EasyAntiCheatPatches
{
    [HarmonyPatch(typeof(EasyAntiCheatRunningChecker), "IsRunning")]
    [HarmonyPrefix]
    static bool EasyAntiCheatIsRunningPatch(ref Task<bool> __result)
    {
        __result = Task.Run(() => true);
        return false;
    }

    // [HarmonyPatch(typeof(GamePlayingEACChecker), "Start")]
    // [HarmonyPrefix]
    // static bool EasyAntiCheatCheckerPatch()
    // {
    //     return false;
    // }
}