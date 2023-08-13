using Photon.Pun;
using UnityEngine;

namespace InternalCheat.Modules.Modules;

public class DismantleModule : BaseModule
{
    public DismantleModule() : base("Dismantle", ModuleType.Button)
    {
    }

    public override void OnUpdate()
    {
        if (!IsInstanced)
        {
            return;
        }

        foreach (var breakableWallEntity in Object.FindObjectsOfType(typeof(BreakableWallEntity)) as BreakableWallEntity[])
        {
            var breakableGroup = new BreakableObjectGroupProvider(breakableWallEntity.ObjectKey, Singleton.Map.AllFloors);
            var gameObject = PhotonNetwork.Instantiate("BreechingCharge", ((Bounds) breakableGroup.m_NeighborFinderBox).center, breakableGroup.m_Rotation);
            var breechingChargeEntity = gameObject.GetComponent<BreechingChargeEntity>();

            MainPlugin.Log.LogInfo("Activate " + breakableGroup.m_ObjectKey.Key);
            breechingChargeEntity.Activate(breakableGroup.m_ObjectKey);
            HackerVoiceManager.Instance.PlayVoiceWithSync(PhotonPlayerContextRepository.LocalPlayerActorNumber, HackerVoiceType.アクション_アビリティ能力1);
        }
    }
}