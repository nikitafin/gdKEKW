using UnityEngine;

namespace Resources.Scripts
{
    public class Fruit : MonoBehaviour
    {
        [Header("Dynamically set")] [SerializeField]
        private GameController gameControllerScript;

        private void Start()
        {
            gameControllerScript = GameObject.FindWithTag("GameControllerTag").GetComponent<GameController>();
        }

        void Update()
        {
            if (transform.position.y < ScreenWrapper.ScreenBottom)
            {
                Destroy(gameObject);
                gameControllerScript.MisFruit();
            }
        }
    }
}