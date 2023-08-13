namespace InternalCheat.Modules.Modules;

public class AimBotModule : BaseModule
{
   public AimBotModule() : base("Aim Bot", ModuleType.Toggle)
   {
   }

   public override void OnUpdate()
   {
      if (!IsInstanced)
      {
         return;
      }
   }
}