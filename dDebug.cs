using UnityEngine;

public static class dDebug
{
    #region Line Sphere
    public static void DrawLineSphere(Vector3 pos, float radius)
    {
        DrawCircleXY(pos, radius);
        DrawCircleYZ(pos, radius);
        DrawCircleXZ(pos, radius);
    }
    public static void DrawLineSphere(Vector3 pos, float radius, Color color)
    {
        DrawCircleXY(pos, radius, color);
        DrawCircleYZ(pos, radius, color);
        DrawCircleXZ(pos, radius, color);
    }
    public static void DrawLineSphere(Vector3 pos, float radius, Color color, float duration)
    {
        DrawCircleXY(pos, radius, color, duration);
        DrawCircleYZ(pos, radius, color, duration);
        DrawCircleXZ(pos, radius, color, duration);
    }
    #endregion

    #region XY
    public static void DrawCircleXY(Vector3 pos, float radius)
    {
        DrawCircleXY(pos, radius, Color.white, 0);
    }
    public static void DrawCircleXY(Vector3 pos, float radius, Color color)
    {
        DrawCircleXY(pos, radius, color, 0);
    }
    public static void DrawCircleXY(Vector3 pos, float radius, Color color, float duration)
    {
        for (float i = 0; i < Mathf.PI * 2; i += (Mathf.PI * 2) * .01f)
        {
            Vector3 p1 = new Vector3(Mathf.Cos(i), Mathf.Sin(i), 0) * radius;
            Vector3 p2 = new Vector3(Mathf.Cos(i + (Mathf.PI * 2f) * .01f), Mathf.Sin(i + (Mathf.PI * 2f) * .01f), 0) * radius;
            if (duration > 0)
                Debug.DrawLine(pos + p1, pos + p2, color, duration);
            else
                Debug.DrawLine(pos + p1, pos + p2, color);
        }
    }
    #endregion

    #region YZ
    public static void DrawCircleYZ(Vector3 pos, float radius)
    {
        DrawCircleYZ(pos, radius, Color.white, 0);
    }
    public static void DrawCircleYZ(Vector3 pos, float radius, Color color)
    {
        DrawCircleYZ(pos, radius, color, 0);
    }
    public static void DrawCircleYZ(Vector3 pos, float radius, Color color, float duration)
    {
        for (float i = 0; i < Mathf.PI * 2; i += (Mathf.PI * 2) * .01f)
        {
            Vector3 p1 = new Vector3(0, Mathf.Cos(i), Mathf.Sin(i)) * radius;
            Vector3 p2 = new Vector3(0, Mathf.Cos(i + (Mathf.PI * 2f) * .01f), Mathf.Sin(i + (Mathf.PI * 2f) * .01f)) * radius;
            if (duration > 0)
                Debug.DrawLine(pos + p1, pos + p2, color, duration);
            else
                Debug.DrawLine(pos + p1, pos + p2, color);
        }
    }
    #endregion

    #region XZ
    public static void DrawCircleXZ(Vector3 pos, float radius)
    {
        DrawCircleXZ(pos, radius, Color.white, 0);
    }
    public static void DrawCircleXZ(Vector3 pos, float radius, Color color)
    {
        DrawCircleXZ(pos, radius, color, 0);
    }
    public static void DrawCircleXZ(Vector3 pos, float radius, Color color, float duration)
    {
        for (float i = 0; i < Mathf.PI * 2; i += (Mathf.PI * 2) * .01f)
        {
            Vector3 p1 = new Vector3(Mathf.Cos(i), 0, Mathf.Sin(i)) * radius;
            Vector3 p2 = new Vector3(Mathf.Cos(i + (Mathf.PI * 2f) * .01f), 0, Mathf.Sin(i + (Mathf.PI * 2f) * .01f)) * radius;
            if (duration > 0)
                Debug.DrawLine(pos + p1, pos + p2, color, duration);
            else
                Debug.DrawLine(pos + p1, pos + p2, color);
        }
    }
    #endregion
}