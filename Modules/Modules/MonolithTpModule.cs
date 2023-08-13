namespace InternalCheat.Modules.Modules;

public class MonolithTpModule : BaseModule
{
   public MonolithTpModule() : base("Monolith Tp", ModuleType.Button)
   {
   }

   public override void OnUpdate()
   {
      if (!IsInstanced)
      {
         return;
      }

      if (PlayerEntityRepository.Instance.TryGetLocalPlayer(out var localPlayer))
      {
         Singleton.Monolith.ChangePosition(localPlayer.Context.PlayerPosition);
      }
   }
}