using UnityEngine;

namespace Resources.Scripts
{
    public class GameController : MonoBehaviour
    {
        private static GameObject ball;
        private static GameObject paddle;

        private static Paddle paddleScript;


        private Transform ballSpawn;

        private GameObject ballPrefab;

        private void Awake()
        {
            ballPrefab = UnityEngine.Resources.Load<GameObject>("Prefabs/Ball");
        }

        private void Start()
        {
            ball = null;
            paddle = GameObject.Find("Paddle");
            paddleScript = paddle.GetComponent<Paddle>();

            if (paddle == null)
            {
                Debug.LogError("No Paddle Object");
                return;
            }

            ballSpawn = paddle.GetComponentInChildren<Transform>();
        }

        private void Update()
        {
            if (Input.GetButtonUp("InitBall") && ball == null)
            {
                var temp = Instantiate(ballPrefab, ballSpawn.position, ballSpawn.rotation);
                temp.GetComponent<Ball>().Init();
                ball = temp;
            }

            if (ball)
            {
                if (ball.GetComponent<Rigidbody2D>().position.y < paddle.GetComponent<Rigidbody2D>().position.y)
                {
                    Destroy(ball);
                }
            }
        }
    }
}