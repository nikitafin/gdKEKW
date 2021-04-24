using UnityEngine;

namespace Sripts
{
    public class Timer : MonoBehaviour
    {
        private float timeRemaining;
        private bool isRunning;

        public float TimeRemaining
        {
            get => timeRemaining;

            set
            {
                if (!isRunning)
                {
                    timeRemaining = value;
                }
            }
        }

        public bool IsRunning => isRunning;

        private void Update()
        {
            if (isRunning)
            {
                timeRemaining -= Time.deltaTime;
                if (timeRemaining <= 0)
                {
                    isRunning = false;
                }
            }
        }

        public void Run()
        {
            if (timeRemaining > 0)
            {
                isRunning = true;
            }
        }
    }
}