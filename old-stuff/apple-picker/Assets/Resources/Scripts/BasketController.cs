using System;
using UnityEngine;

namespace Resources.Scripts
{
    public class BasketController : MonoBehaviour
    {
        private GameController gameControllerScript;

        private Rigidbody2D rd2D;
        private BoxCollider2D bc2d;

        [SerializeField] private float xVelocity;
        private float inputAmount;
        private float halfWidth;
        private float halfHeight;

        private void Awake()
        {
            gameControllerScript = GameObject.FindWithTag("GameControllerTag").GetComponent<GameController>();
            rd2D = GetComponent<Rigidbody2D>();
            bc2d = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            var bounds = bc2d.bounds;
            halfWidth = bounds.extents.x;
            halfHeight = bounds.extents.y;
        }


        private void Update()
        {
            inputAmount = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            Vector2 newPos = rd2D.position + Vector2.right * (inputAmount * xVelocity * Time.fixedDeltaTime);
            newPos.x = Mathf.Clamp(newPos.x, ScreenWrapper.ScreenLeft + halfWidth,
                ScreenWrapper.ScreenRight - halfHeight);
            rd2D.MovePosition(newPos);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Fruit"))
            {
                Destroy(other.gameObject);
                ++gameControllerScript.Score;
            }
        }
    }
}