using HarmonyLib;

namespace InternalCheat.Patches;

// TODO :: 🤔🤔🤔
public class InstantBreakPatches
{
	[HarmonyPatch(typeof(BreechingChargeState), "Enter", typeof(PlayerStateContext))]
	[HarmonyPrefix]
	static bool EnterPatch(object[] __args, ref float ___m_OparationNeedTime, ref float ___m_ExitWaitTime)
	{
		((PlayerStateContext)__args[0]).PlayerWeaponManager.EquipGadget();
		Singleton.GameSystem.HUD.Cursor.SetReticle(ReticleType.Dot);
		___m_OparationNeedTime = 0.02f;
		___m_ExitWaitTime = 0.15f;
		return false;
	}

	[HarmonyPatch(typeof(BreakableObjectGroupProvider), "GetCanBreak")]
	[HarmonyPrefix]
	static bool CanBreakPatch(ref bool __result)
	{
		__result = true;
		return false;
	}
}