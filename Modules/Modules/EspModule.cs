using InternalCheat.Helpers;
using UnityEngine;

namespace InternalCheat.Modules.Modules;

public class EspModule : BaseModule
{
    public EspModule() : base("ESP", ModuleType.Toggle)
    {
    }

    public override void OnScreen()
    {
        if (!IsInstanced)
        {
            return;
        }

        foreach (var player in PlayerEntityRepository.Instance.GetAll())
        {
            if (player.Context.IsMe || player.Context.IsDead)
            {
                continue;
            }

            var boxColor = player.Context.Team == PhotonPlayerContextRepository.LocalPlayer.Team ? Color.white : new Color(255, 60, 60);
            RenderBox(player.Entity.gameObject, player.Context.PlayerName, boxColor);
        }
    }

    private void RenderBox(GameObject gameObject, string label, Color color)
    {
        var position = gameObject.transform.position;
        var headPos = new Vector3(position.x, position.y + 1.7f, position.z);
        var screenFootPos = Camera.main.WorldToScreenPoint(position);
        var screenHeadPos = Camera.main.WorldToScreenPoint(headPos);
        if (screenFootPos.z <= 0)
        {
            return;
        }

        var boxHeight = screenHeadPos.y - screenFootPos.y;
        var boxWidth = boxHeight / 1.6f;
        var boxX = screenFootPos.x - boxWidth / 2;
        var boxY = Screen.height - screenFootPos.y - boxHeight;
        RenderHelper.DrawBox(boxX, boxY, boxWidth, boxHeight, Color.black, 3.5f);
        RenderHelper.DrawBox(boxX, boxY, boxWidth, boxHeight, color, 1.5f);
        RenderHelper.DrawString(new Vector2(boxX + boxWidth / 2, boxY - 1.5f), label, Color.white, GUI.skin.label);
    }
}