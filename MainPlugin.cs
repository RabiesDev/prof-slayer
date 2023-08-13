using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using InternalCheat.Modules;
using InternalCheat.Modules.Modules;
using InternalCheat.Patches;
using InternalCheat.Patches.AntiCheat;
using InternalCheat.Patches.IntegrityCheck;
using InternalCheat.Patches.UnityEngine;
using Photon.Pun;

namespace InternalCheat;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInProcess("Project F.exe")]
public class MainPlugin : BaseUnityPlugin
{
    public static readonly List<BaseModule> Modules = new();
    public static readonly ManualLogSource Log = new(PluginInfo.PLUGIN_NAME);
    public static readonly string NewUuid = Guid.NewGuid().ToString();
    public static readonly string NewName = "I am using cheats 🤡";
    public static PhotonView PhotonView;

    private void Awake()
    {
        Logger.LogInfo("Preparing modules");
        Modules.Add(new AccountSpoofModule());
        Modules.Add(new GlowEspModule());
        Modules.Add(new EspModule());
        Modules.Add(new AllKillModule());
        Modules.Add(new OtherKillModule());
        Modules.Add(new EnemyKillModule());
        Modules.Add(new MonolithTpModule());
        Modules.Add(new DismantleModule());
        Modules.Add(new FastSpeedModule());
        Modules.Add(new AirJumpModule());
        Modules.Add(new SuperAttackModule());
        Modules.Add(new NoRecoilingModule());
        Modules.Add(new FastShootModule());
        Modules.Add(new RegenModule());

        Logger.LogInfo("Patching");
        Harmony.CreateAndPatchAll(typeof(AntiCheatToolkitPatches));
        Harmony.CreateAndPatchAll(typeof(GanymedePatches));
        Harmony.CreateAndPatchAll(typeof(EasyAntiCheatPatches));
        Harmony.CreateAndPatchAll(typeof(IntegrityCheckPatches));
        Harmony.CreateAndPatchAll(typeof(SystemInfoPatches));

        Harmony.CreateAndPatchAll(typeof(AccountSpoofPatches));
        Harmony.CreateAndPatchAll(typeof(InfiniteGunBulletPatches));
        Harmony.CreateAndPatchAll(typeof(SuperAttackPatches));
        Harmony.CreateAndPatchAll(typeof(FastShootPatches));
        Harmony.CreateAndPatchAll(typeof(NoRecoilingPatches));
        Harmony.CreateAndPatchAll(typeof(UnlimitedBuyPatches));
        Harmony.CreateAndPatchAll(typeof(InstantBreakPatches));
        Harmony.CreateAndPatchAll(typeof(TeamKillPatches));
        Harmony.CreateAndPatchAll(typeof(FastSpeedPatches));
        Harmony.CreateAndPatchAll(typeof(AirJumpPatches));
        Harmony.CreateAndPatchAll(typeof(KeepDashPatches));
        Harmony.CreateAndPatchAll(typeof(KeepJumpPatches));
        Harmony.CreateAndPatchAll(typeof(AntiReconnectPatches));
        Harmony.CreateAndPatchAll(typeof(DebugLogPatches));

        BepInEx.Logging.Logger.Sources.Add(Log);
        Logger.LogInfo("Ready");
    }

    private void Start()
    {
        PhotonView = GetComponent<PhotonView>();
        Modules.ForEach(module =>
        {
            module.OnStart();
        });
        Interfaces.DoStart();
    }

    private void Update()
    {
        Modules.ForEach(module =>
        {
            if (module.Activated)
            {
                module.OnUpdate();
            }
        });
    }

    private void OnGUI()
    {
        Modules.ForEach(module =>
        {
            if (module.Activated)
            {
                module.OnScreen();
            }
        });
        Interfaces.DoRender();
    }

    public static bool IsActivated(string name)
    {
        var module = Modules.Find(module => module.Name.Equals(name));
        return module is { Activated: true };
    }
}