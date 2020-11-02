using UnityEngine;

public class Paddle : MonoBehaviour
{

    private Rigidbody2D rb2D;
    private float horizontalInput;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(transform.position + Vector3.right * horizontalInput * 12f * Time.fixedDeltaTime);
    }
}