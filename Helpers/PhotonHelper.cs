using System;
using System.Numerics;
using Photon.Pun;

namespace InternalCheat.Helpers;

public static class PhotonHelper
{
    public static void ActivateBreak(IBreakableObjectGroupKey objectGroupKey)
    {
        if (objectGroupKey is BreakableFloorGroupKey breakableFloorGroupKey)
        {
            MainPlugin.PhotonView.RPC("ActivateRPC", RpcTarget.All, true, breakableFloorGroupKey.Center,breakableFloorGroupKey.CenterBlueprint, Vector2.Zero);
            return;
        }

        if (objectGroupKey is not BreakableWallGroupKey breakableWallGroupKey)
        {
            throw new Exception("不明なIBreakableObjectGroupKey : " + objectGroupKey.GetType().Name);
        }

        MainPlugin.PhotonView.RPC("ActivateRPC", RpcTarget.All, false, breakableWallGroupKey.Center,breakableWallGroupKey.Segment.P0, breakableWallGroupKey.Segment.P1);
    }
}