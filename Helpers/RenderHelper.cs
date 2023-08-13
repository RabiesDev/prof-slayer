using UnityEngine;

namespace InternalCheat.Helpers;

public static class RenderHelper
{
    private static readonly GUIStyle StringStyle = new(GUI.skin.label);
    private static readonly Texture2D LineTexture = new(1, 1);

    public static void DrawString(Vector2 position, string label, Color color, GUIStyle style, bool centered = true)
    {
        GUI.color = color;
        DrawString(position, label, style, centered);
    }

    public static void DrawString(Vector2 position, string label, GUIStyle style, bool centered = true)
    {
        var content = new GUIContent(label);
        var size = StringStyle.CalcSize(content);
        var upperLeft = centered ? position - size / 2f : position;
        GUI.Label(new Rect(upperLeft, size), new GUIContent(label), style);
    }

    public static void DrawBox(float left, float top, float width, float height, Color color, float thickness)
    {
        var topLeft = new Vector2(left, top);
        var topRight = topLeft + new Vector2(width, 0);
        var bottomLeft = topLeft + new Vector2(0, height);
        var bottomRight = topLeft + new Vector2(width, height);
        DrawLine(topLeft, topRight, color, thickness);
        DrawLine(topLeft, bottomLeft, color, thickness);
        DrawLine(topRight, bottomRight, color, thickness);
        DrawLine(bottomLeft, bottomRight, color, thickness);
    }

    public static void DrawLine(Vector2 startPoint, Vector2 endPoint, Color color, float thickness)
    {
        var previousMatrix = GUI.matrix;
        GUI.color = color;

        var angle = Vector2.Angle(Vector2.right, endPoint - startPoint);
        if (endPoint.y < startPoint.y)
        {
            angle = -angle;
        }

        GUIUtility.ScaleAroundPivot(new Vector2(Vector2.Distance(startPoint, endPoint), thickness),startPoint + 0.5f * Vector2.up);
        GUIUtility.RotateAroundPivot(angle, startPoint);
        GUI.DrawTexture(new Rect(startPoint.x, startPoint.y, 1, 1), LineTexture);
        GUI.matrix = previousMatrix;
    }
}