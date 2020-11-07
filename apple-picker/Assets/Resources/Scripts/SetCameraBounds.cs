using UnityEngine;


namespace Resources.Scripts
{
    /** 
    * https://github.com/UnityCommunity/UnityLibrary/blob/master/Assets/Scripts/2D/Colliders/ScreenEdgeColliders.cs
    */
    public class SetCameraBounds : MonoBehaviour
    {
        private Camera mainCamera;
        private EdgeCollider2D edgeCollider2D;
        private Vector2[] edgePoints;

        private void Awake()
        {
            if (Camera.main == null || !Camera.main.orthographic)
            {
                Debug.LogError("Camera.main not found or not orthographic");
            }

            mainCamera = Camera.main;
            edgeCollider2D = gameObject.AddComponent<EdgeCollider2D>();
            edgePoints = new Vector2[5];

            Vector2 bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0,
                mainCamera.nearClipPlane));

            Vector2 topRight = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth,
                mainCamera.pixelHeight, mainCamera.nearClipPlane));

            Vector2 topLeft = new Vector2(bottomLeft.x, topRight.y);

            Vector2 bottomRight = new Vector2(topRight.x, bottomLeft.y);

            edgePoints[0] = bottomLeft;
            edgePoints[1] = topLeft;
            edgePoints[2] = topRight;
            edgePoints[3] = bottomRight;
            edgePoints[4] = bottomLeft;

            edgeCollider2D.points = edgePoints;
            edgeCollider2D.isTrigger = true;
        }
    }
}