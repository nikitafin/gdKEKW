using Sripts;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 direction;
    private const float BulletSpeed = 5f;

    // void Start()
    // {
    //     direction = new Vector2(1f, 1f);
    // }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        position += direction * (BulletSpeed * Time.deltaTime);
        transform.position = position;
        var o = gameObject;
        ScreenWrapper.Wrap(ref o);
    }


    public Vector2 Direction
    {
        get => direction;
        set => direction = value;
    }
}