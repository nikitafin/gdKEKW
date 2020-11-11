using UnityEngine;

/* 
 github.com/UnityCommunity/UnityLibrary/
 blob/master/Assets/Scripts/2D/Colliders/ScreenEdgeColliders.cs
*/

public class ScreenEdgeColliders : MonoBehaviour
{
    [Header("Set bounced physics material")]
    public PhysicsMaterial2D physicsMaterial2D;
    private Camera cam;
    private EdgeCollider2D edgeCollider2D;
    Vector2[] edgePoints;

    void Awake()
    {
        if (Camera.main == null || !Camera.main.orthographic)
        {
            Debug.LogError("Camera.main not found or not orthographic");
        }
        cam = Camera.main;
        edgeCollider2D = gameObject.AddComponent<EdgeCollider2D>();
        if (physicsMaterial2D != null)
        {
            edgeCollider2D.sharedMaterial = physicsMaterial2D;
        }
        edgePoints = new Vector2[5];

        AddColliders();
    }
    private void AddColliders()
    {
        //Vector2's for the corners of the screen
        Vector2 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector2 topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        Vector2 topLeft = new Vector2(bottomLeft.x, topRight.y);
        Vector2 bottomRight = new Vector2(topRight.x, bottomLeft.y);

        //Update Vector2 array for edge collider
        edgePoints[0] = bottomLeft;
        edgePoints[1] = topLeft;
        edgePoints[2] = topRight;
        edgePoints[3] = bottomRight;
        edgePoints[4] = bottomLeft;

        edgeCollider2D.points = edgePoints;
    }
}
