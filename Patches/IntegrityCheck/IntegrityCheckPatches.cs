using BuildTools.IntegrityCheck.Check;
using BuildTools.IntegrityCheck.Data;
using HarmonyLib;

namespace InternalCheat.Patches.IntegrityCheck;

public class IntegrityCheckPatches
{
    [HarmonyPatch(typeof(StartUpIntegrityCheck), "Start")]
    static bool StartIntegrityCheckPatch()
    {
        return false;
    }

    [HarmonyPatch(typeof(FileIntegrityCheckService), "Check", typeof(RsaKeys), typeof(string))]
    [HarmonyPrefix]
    static bool FileIntegrityCheckPatch(ref bool __result)
    {
        __result = true;
        return false;
    }
}