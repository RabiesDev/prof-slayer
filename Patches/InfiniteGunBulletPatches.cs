using HarmonyLib;

namespace InternalCheat.Patches;

public class InfiniteGunBulletPatches
{
    [HarmonyPatch(typeof(GunBulletManager), "MagazineBullet", MethodType.Getter)]
    [HarmonyPrefix]
    static bool MagazineBulletPatch(ref int __result)
    {
        __result = 1337;
        return false;
    }

    [HarmonyPatch(typeof(GunBulletManager), "BackpackBullet", MethodType.Getter)]
    [HarmonyPrefix]
    static bool BackpackBulletPatch(ref int __result)
    {
        __result = 1337;
        return false;
    }
}