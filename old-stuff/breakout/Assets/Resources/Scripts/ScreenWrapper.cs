using UnityEngine;

namespace Resources.Scripts
{
    public static class ScreenWrapper
    {
        #region Fields

        private static int screenWidth;
        private static int screenHeight;

        private static float screenLeft;
        private static float screenRight;
        private static float screenTop;
        private static float screenBottom;

        #endregion

        #region Methods

        public static void Init()
        {
            screenWidth = Screen.width;
            screenHeight = Screen.height;

            if (!(Camera.main is null))
            {
                var screenZ = -Camera.main.transform.position.z;

                Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, screenZ));
                Vector3 upperLeftCornerWorld =
                    Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, screenZ));

                screenLeft = lowerLeftCornerWorld.x;
                screenRight = upperLeftCornerWorld.x;
                screenTop = upperLeftCornerWorld.y;
                screenBottom = lowerLeftCornerWorld.y;
            }
            else
            {
                Debug.LogError("None camera on scene");
            }
        }

        public static void Resize()
        {
            if (screenWidth != Screen.width || screenHeight != Screen.height)
            {
                Init();
            }
        }

        #endregion

        #region Properties

        public static float ScreenLeft
        {
            get
            {
                Resize();
                return screenLeft;
            }
        }

        public static float ScreenRight
        {
            get
            {
                Resize();
                return screenRight;
            }
        }

        public static float ScreenTop
        {
            get
            {
                Resize();
                return screenTop;
            }
        }

        public static float ScreenBottom
        {
            get
            {
                Resize();
                return screenBottom;
            }
        }

        #endregion
    }
}