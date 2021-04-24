using UnityEngine;
using UnityEngine.UIElements;

namespace Resources.Scripts
{
    public class Ball : MonoBehaviour
    {
        private Rigidbody2D rb2D;
        private BoxCollider2D bc2D;


        private const float StartAngle = 120;
        private const float BallImpulseForce = 5;


        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
            bc2D = GetComponent<BoxCollider2D>();
        }

        public void Init()
        {
            rb2D.AddForce(
                new Vector2(Mathf.Cos(StartAngle * Mathf.Deg2Rad), Mathf.Sin(StartAngle * Mathf.Deg2Rad)) *
                BallImpulseForce,
                ForceMode2D.Impulse);
        }

        public void SetDirection(Vector2 newDir)
        {
            rb2D.velocity = newDir * rb2D.velocity.magnitude;
        }


        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
    }
}