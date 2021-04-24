using UnityEngine;
using UnityEngine.Assertions;

public static class Stuff
{
    public static int ScreenWidth { get; private set; }
    public static int ScreenHeight { get; private set; }
    public static float CameraWidth { get; private set; }
    public static float CameraHeight { get; private set; }
    private static float _screenLeft;
    private static float _screenRight;
    private static float _screenTop;
    private static float _screenBottom;

    public static void Init()
    {
        Debug.Log("Utils");

        var cam = Camera.main;
        Assert.IsNotNull(cam);
        Assert.IsFalse(!cam.orthographic);

        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
        var temp = cam.ScreenToWorldPoint(new Vector3(ScreenWidth, ScreenHeight, 0f));
        CameraWidth = temp.x;
        CameraHeight = temp.y;

        var screenZ = cam.transform.position.z;

        Vector3 lowerLeftCornerWorld = cam.ScreenToWorldPoint(new Vector3(0, 0, screenZ));
        Vector3 upperLeftCornerWorld =
            cam.ScreenToWorldPoint(new Vector3(ScreenWidth, ScreenHeight, screenZ));

        _screenLeft = lowerLeftCornerWorld.x;
        _screenRight = upperLeftCornerWorld.x;
        _screenTop = upperLeftCornerWorld.y;
        _screenBottom = lowerLeftCornerWorld.y;
    }

    private static void Resize()
    {
        if (ScreenWidth != Screen.width || ScreenHeight != Screen.height)
        {
            Init();
        }
    }

    public static float ScreenLeft
    {
        get
        {
            Resize();
            return _screenLeft;
        }
    }

    public static float ScreenRight
    {
        get
        {
            Resize();
            return _screenRight;
        }
    }

    public static float ScreenTop
    {
        get
        {
            Resize();
            return _screenTop;
        }
    }

    public static float ScreenBottom
    {
        get
        {
            Resize();
            return _screenBottom;
        }
    }
}