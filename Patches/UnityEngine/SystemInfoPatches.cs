using System;
using System.Linq;
using HarmonyLib;
using UnityEngine;

namespace InternalCheat.Patches.UnityEngine;

public class SystemInfoPatches
{
    [HarmonyPatch(typeof(SystemInfo), "deviceUniqueIdentifier", MethodType.Getter)]
    [HarmonyPrefix]
    static bool HwidPatch(ref string __result)
    {
        var random = new System.Random(Environment.TickCount);
        var bytes = new byte[SystemInfo.deviceUniqueIdentifier.Length / 2];
        random.NextBytes(bytes);
        __result = string.Join("", bytes.Select(it => it.ToString("x2")));
        return false;
    }
}