using System;
using System.ComponentModel.Design;
using UnityEngine;

namespace Sripts
{
    public class Bullet : MonoBehaviour
    {
        private Timer timerScript;
        private Animator animator;
        private CircleCollider2D cc2d;
        private Vector2 direction;
        private const float BulletSpeed = 14f;

        private void Awake()
        {
            timerScript = GetComponent<Timer>();
            animator = GetComponent<Animator>();
            cc2d = GetComponent<CircleCollider2D>();
        }

        private void Update()
        {
            if (!timerScript.IsRunning)
            {
                Destruction();
            }
        }

        private void FixedUpdate()
        {
            Vector2 position = transform.position;
            position += direction * (BulletSpeed * Time.deltaTime);
            transform.position = position;
            ScreenWrapper.Wrap(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Asteroid"))
            {
                other.gameObject.GetComponent<Asteroid>().Destruction();
                Destruction();
            }
        }

        public void Init(Vector2 initDirection)
        {
            direction = initDirection;
            // set lifetime
            timerScript.TimeRemaining = 1.5f;
            timerScript.Run();
            gameObject.name = "bullet";
        }

        private void Destruction()
        {
            animator.Play("BulletExplosion 0");
            cc2d.enabled = false;
            Destroy(gameObject, 0.07f);
        }

        #region Properties

        public Vector2 Direction { get; set; }

        #endregion
    }
}