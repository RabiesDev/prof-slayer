using InternalCheat.Modules;
using UnityEngine;

namespace InternalCheat;

public static class Interfaces
{
    private static Vector2 _scrollPosition = Vector2.zero;
    private static Rect _scrollViewRect;
    private static Rect _viewRect;
    private static Rect[] _contentRects;
    private static bool _expanded;
    private static int _contentLen;

    public static void DoStart()
    {
        _contentLen = MainPlugin.Modules.Count + 1;
        _scrollViewRect = new Rect(10, 50, 180, 35 * 7);
        _viewRect = new Rect(10, 50, 160, 45 * (_contentLen + 2));

        var baseRect = new Rect(10, 50, 160, 35);
        _contentRects = new Rect[_contentLen];
        _contentRects[0] = baseRect;
        for (var i = 1; i < _contentLen; i++)
        {
            _contentRects[i] = baseRect;
            _contentRects[i].y *= i + 1;
        }
    }

    public static void DoRender()
    {
        var watermarkStyle = GUI.skin.label;
        watermarkStyle.fontSize = 25;
        GUI.Label(new Rect(10, 10, 1000, 40), "CLUB MACHINE", watermarkStyle);

        if (!_expanded)
        {
            if (GUI.Button(new Rect(10, 50, 160, 35), "Expand"))
            {
                MainPlugin.Log.LogInfo("pressed");
                _expanded = true;
            }

            return;
        }

        _scrollPosition = GUI.BeginScrollView(_scrollViewRect, _scrollPosition, _viewRect);
        for (var i = 0; i < _contentRects.Length; i++)
        {
            var rect = _contentRects[i];
            if (i == 0 && GUI.Button(rect, "Close"))
            {
                _expanded = false;
            }
            else
            {
                var module = MainPlugin.Modules[i - 1];
                if (module.ModuleType == ModuleType.Toggle)
                {
                    var status = module.Activated ? "<color=green>Enabled</color>" : "<color=red>Disabled</color>";
                    if (GUI.Button(rect, $"{module.Name} : {status}"))
                    {
                        module.Activated = !module.Activated;
                    }
                }
                else if (module.ModuleType == ModuleType.Button && GUI.Button(rect, module.Name))
                {
                    MainPlugin.Log.LogInfo(module.Name);
                    module.OnUpdate();
                }
            }
        }
        GUI.EndScrollView();
    }
}