using System;
using UnityEngine;

namespace Resources.Scripts
{
    public class Paddle : MonoBehaviour
    {
        private Rigidbody2D rb2D;
        private BoxCollider2D bc2D;


        [SerializeField] [Header("Set In Editor")]
        private float xVelocity;

        private float horizontalInput;
        private float halfWidth;
        private float halfHeight;


        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
            bc2D = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            var bounds = bc2D.bounds.extents;
            halfWidth = bounds.x;
            halfHeight = bounds.y;
        }

        private void Update()
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            Vector2 newPosition = rb2D.position + Vector2.right * (horizontalInput * xVelocity * Time.fixedDeltaTime);
            // stay new position in camera view
            newPosition.x = Mathf.Clamp(newPosition.x, ScreenWrapper.ScreenLeft + halfWidth,
                ScreenWrapper.ScreenRight - halfWidth);
            newPosition.y = Mathf.Clamp(newPosition.y, ScreenWrapper.ScreenBottom + halfHeight,
                ScreenWrapper.ScreenTop - halfHeight);

            rb2D.MovePosition(newPosition);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Ball"))
            {
                return;
            }

            float paddleCenterOffset = transform.position.x - other.gameObject.transform.position.x;
            paddleCenterOffset /= halfWidth;
            float angleOffset = paddleCenterOffset * 60 * Mathf.Deg2Rad;
            float angle = angleOffset + Mathf.PI / 2;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            other.gameObject.GetComponent<Ball>().SetDirection(direction);
        }
    }
}