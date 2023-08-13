using Storage;

namespace InternalCheat.Modules.Modules;

public class AccountSpoofModule : BaseModule
{
    public AccountSpoofModule() : base("Account Spoof", ModuleType.Toggle)
    {
        Activated = true;
    }

    public override void OnUpdate()
    {
        StorageBase<ConfigPreference>.Instance.m_NickName = MainPlugin.NewName;
        // StorageBase<ConfigPreference>.Instance.m_UuId = InternalCheatPlugin.NewUuid;
    }
}