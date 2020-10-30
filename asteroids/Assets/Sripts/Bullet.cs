using System.ComponentModel.Design;
using UnityEngine;

namespace Sripts
{
    public class Bullet : MonoBehaviour
    {
        private Timer timerScript;
        private Animator animator;
        private Vector2 direction;
        private const float BulletSpeed = 14f;

        void Start()
        {
            timerScript = GetComponent<Timer>();
            animator = GetComponent<Animator>();
            // set lifetime to 2 second
            timerScript.TimeRemaining = 2.0f;
            timerScript.Run();
        }

        private void Update()
        {
            if (!timerScript.IsRunning)
            {
                Destrucion();
            }
        }

        public void Destrucion()
        {
            animator.Play("BulletExplosion 0");
            Destroy(gameObject, 0.05f);
        }

        private void FixedUpdate()
        {
            Vector2 position = transform.position;
            position += direction * (BulletSpeed * Time.deltaTime);
            transform.position = position;
            ScreenWrapper.Wrap(gameObject);
        }


        public Vector2 Direction
        {
            get => direction;
            set => direction = value;
        }
    }
}