namespace InternalCheat.Modules.Modules;

public class GlowEspModule : BaseModule
{
    public GlowEspModule() : base("Glow ESP", ModuleType.Toggle)
    {
        Activated = true;
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

            gamePlayer.Entity.ThirdPersonCharacter.SetOutlineEnabled(true);
        }
    }
}