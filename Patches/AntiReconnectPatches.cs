using HarmonyLib;
using Photon;

namespace InternalCheat.Patches;

public class AntiReconnectPatches
{
    [HarmonyPatch(typeof(RoomReconnectPresenter), "TryGetReconnectInfo")]
    [HarmonyPrefix]
    static bool TryGetReconnectInfoPatch(ref bool __result)
    {
        MainPlugin.Log.LogInfo("Prevented reconnect");
        __result = false;
        return false;
    }
}
