using UnityEngine;

namespace InternalCheat.Modules.Modules;

public class OtherKillModule : BaseModule
{
    public OtherKillModule() : base("Other Kill", ModuleType.Button)
    {
    }

    public override void OnUpdate()
    {
        if (!IsInstanced)
        {
            return;
        }

        foreach (var gamePlayer in PlayerEntityRepository.Instance.GetAll())
        {
            if (gamePlayer.Context.IsMe)
            {
                continue;
            }

            var damage = Input.GetKey(KeyCode.LeftShift) ? int.MaxValue : 1337;
            GamePlayerStatusRPCDispatcher.Instance.AddDamage(gamePlayer.Context.ActorNumber, gamePlayer.Context.ActorNumber, damage, gamePlayer.Context.PlayerPosition, GamePlayerStatusRPCDispatcher.DamageType.GunH, false);
        }
    }
}