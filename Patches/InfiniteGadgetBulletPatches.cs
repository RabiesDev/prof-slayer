using HarmonyLib;

namespace InternalCheat.Patches;

public class InfiniteGadgetBulletPatches
{
    [HarmonyPatch(typeof(GadgetBulletManager), "Bullet", MethodType.Getter)]
    [HarmonyPrefix]
    static bool BulletPatch(ref int __result)
    {
        __result = 1337;
        return false;
    }
    
    [HarmonyPatch(typeof(GadgetBulletManager), "NewBullet", MethodType.Getter)]
    [HarmonyPrefix]
    static bool NewBulletPatch(ref int __result)
    {
        __result = 1337;
        return false;
    }

    [HarmonyPatch(typeof(GadgetBulletManager), "UsedBullet", MethodType.Getter)]
    [HarmonyPrefix]
    static bool UsedBulletPatch(ref int __result)
    {
        __result = 0;
        return false;
    }
}