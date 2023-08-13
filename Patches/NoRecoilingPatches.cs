using Ganymede.Recoiling;
using HarmonyLib;

namespace InternalCheat.Patches;

public class NoRecoilingPatches
{
    [HarmonyPatch(typeof(GunVibrator), "OnFire", typeof(GunVibratorSettings), typeof(float))]
    [HarmonyPatch(typeof(Recoiler), "OnFire")]
    [HarmonyPrefix]
    static bool OnFirePatch()
    {
        return !MainPlugin.IsActivated("No Recoiling");
    }

    [HarmonyPatch(typeof(GunVibrator), "Update")]
    [HarmonyPrefix]
    static bool VibratorPatch()
    {
        return !MainPlugin.IsActivated("No Recoiling");
    }
}