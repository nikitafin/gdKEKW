using UnityEngine;

namespace Sripts
{
    public class Bullet : MonoBehaviour
    {
        private Timer timerScript;
        private Vector2 direction;
        private const float BulletSpeed = 7f;

        void Start()
        {
            timerScript = GetComponent<Timer>();
            // set lifetime to 2 second
            timerScript.TimeRemaining = 2f;
            timerScript.Run();
        }

        private void Update()
        {
            if (!timerScript.IsRunning)
            {
                Destroy(gameObject);
            }
        }

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
}