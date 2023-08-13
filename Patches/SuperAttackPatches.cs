using HarmonyLib;

namespace InternalCheat.Patches;

public class SuperAttackPatches
{
    [HarmonyPatch(typeof(PlayerFireManager), "FireRequest", typeof(GunConfiguration))]
    [HarmonyPrefix]
    static void FireRequestPatch(object[] __args)
    {
        if (!MainPlugin.IsActivated("Super Attack"))
        {
            return;
        }

        GunConfiguration gunConfig = (GunConfiguration)__args[0];
        gunConfig.Parameter.m_Damage = 1337;
        __args[0] = gunConfig;
    }
}