using UnityEngine;

namespace Resources.Scripts
{
    public class GameController : MonoBehaviour
    {
        public int score;

        private void Awake()
        {
            score = 0;
        }
        
        public int Score
        {
            get => score;
            set => score = value;
        }
    }
}
