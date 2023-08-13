namespace InternalCheat.Modules.Modules;

public class AllKillModule : BaseModule
{
    public AllKillModule() : base("All Kill", ModuleType.Button)
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
            GamePlayerStatusRPCDispatcher.Instance.AddDamage(gamePlayer.Context.ActorNumber, gamePlayer.Context.ActorNumber, 1337, gamePlayer.Context.PlayerPosition, GamePlayerStatusRPCDispatcher.DamageType.GunH, false);
        }
    }
}