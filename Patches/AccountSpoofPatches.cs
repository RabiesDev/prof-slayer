using HarmonyLib;
using Photon.Realtime;

namespace InternalCheat.Patches;

public class AccountSpoofPatches
{
    // [HarmonyPatch(typeof(Account), "Uuid", MethodType.Getter)]
    // [HarmonyPrefix]
    // static bool UuidPatch(ref string __result)
    // {
    //     __result = InternalCheatPlugin.NewUuid;
    //     return false;
    // }

    [HarmonyPatch(typeof(Account), "ScreenName", MethodType.Getter)]
    [HarmonyPrefix]
    static bool ScreenNamePatch(ref string __result)
    {
        __result = MainPlugin.NewName;
        return false;
    }

    [HarmonyPatch(typeof(Player), "NickName", MethodType.Getter)]
    [HarmonyPrefix]
    static bool NickNamePatch(Player __instance, ref string __result)
    {
        if (__instance.ActorNumber != PhotonPlayerContextRepository.LocalPlayerActorNumber)
        {
            return true;
        }

        __result = MainPlugin.NewName;
        return false;
    }
}