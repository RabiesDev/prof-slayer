using HarmonyLib;

namespace InternalCheat.Patches;

public class UnlimitedBuyPatches
{
    [HarmonyPatch(typeof(BuyEquipmentState), "BuyGun", typeof(PlayerStateContext), typeof(Equipment.GunType))]
    [HarmonyPrefix]
    static bool BuyGunPatch(object[] __args)
    {
        PlayerStateContext context = (PlayerStateContext)__args[0];
        Equipment.GunType gunType = (Equipment.GunType)__args[1];
        bool isMainWeapon = gunType.GetParameter().m_WeaponType == Equipment.WeaponType.Main;
        context.PlayerWeaponManager.SetAndEquipWeapon(gunType);
        context.PlayerWeaponManager.SetSkin(isMainWeapon, AccountItemManager.Instance.GetMyGunSkin(gunType).ItemId);
        if (isMainWeapon)
        {
            Singleton.GameSystem.HUD.BuyUI.BuyMainWeapon(gunType);
        }
        else
        {
            Singleton.GameSystem.HUD.BuyUI.BuySubWeapon(gunType);
        }
        return false;
    }

    [HarmonyPatch(typeof(BuyEquipmentState), "BuyArmor", typeof(Equipment.Armor))]
    [HarmonyPrefix]
    static bool BuyArmor(object[] __args)
    {
        Equipment.Armor armor = (Equipment.Armor)__args[0];
        PlayerGameProperty.Me.Modify(delegate(IPlayerPropertyWriter propertyWriter)
        {
            propertyWriter.Armor = armor;
            propertyWriter.ArmorHp = armor.GetHP();
            propertyWriter.MaxArmorHp = armor.GetHP();
            Singleton.GameSystem.HUD.BuyUI.ChangeArmor(armor);
        });
        return false;
    }

    [HarmonyPatch(typeof(BuyEquipmentState), "BuyHelmet")]
    [HarmonyPrefix]
    static bool BuyHelmet(object[] __args)
    {
        Equipment.Helmet helmet = (Equipment.Helmet)__args[0];
        PlayerGameProperty.Me.Modify(delegate(IPlayerPropertyWriter propertyWriter)
        {
            propertyWriter.Helmet = helmet;
            propertyWriter.HelmetHp = helmet.GetHP();
            propertyWriter.MaxHelmetHp = helmet.GetHP();
            Singleton.GameSystem.HUD.BuyUI.BuyHelmet(helmet);
        });
        return false;
    }

    [HarmonyPatch(typeof(BuyEquipmentState), "BuyGadget")]
    [HarmonyPrefix]
    static bool BuyGadgetPatch()
    {
        PlayerGameProperty.Me.Modify(delegate(IPlayerPropertyWriter propertyWriter)
        {
            propertyWriter.NewGadgetCount = 1337;
            Singleton.GameSystem.HUD.BuyUI.SetGadgetNumberOwned(1337,1337);
        });
        return false;
    }
}