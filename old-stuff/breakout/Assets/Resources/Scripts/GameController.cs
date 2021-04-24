using UnityEngine;
using UnityEngine.UI;

namespace Resources.Scripts
{
    public class GameController : MonoBehaviour
    {
        private static GameObject ball;
        private static GameObject paddle;
        private static GameObject currentScoreGO;
        private static GameObject maxScoreGO;
        private static GameObject ballLeftGO;


        private static Paddle paddleScript;
        private static Ball ballScript;


        private Transform ballSpawn;
        private GameObject ballPrefab;

        private Text currentScoreText;
        private Text maxScoreText;

        private SpriteRenderer[] lifeSpriteRenderers;


        private bool ballInGame;
        private int lifeCount;


        private void Awake()
        {
            ballPrefab = UnityEngine.Resources.Load<GameObject>("Prefabs/Ball");

            currentScoreGO = GameObject.Find("CurrentScore");
            maxScoreGO = GameObject.Find("MaxScore");
            ballLeftGO = GameObject.Find("BallLeft");

            currentScoreText = currentScoreGO.GetComponent<Text>();
            maxScoreText = maxScoreGO.GetComponent<Text>();
            lifeSpriteRenderers = ballLeftGO.GetComponentsInChildren<SpriteRenderer>();
        }

        private void Start()
        {
            ball = null;
            ballInGame = false;
            paddle = GameObject.Find("Paddle");
            paddleScript = paddle.GetComponent<Paddle>();

            if (paddle == null)
            {
                Debug.LogError("No Paddle Object");
                return;
            }

            ballSpawn = paddle.GetComponentInChildren<Transform>();
            lifeCount = 3;
        }

        private void Update()
        {
            if (!ball)
            {
                var temp = Instantiate(ballPrefab, ballSpawn.position, ballSpawn.rotation);
                ball = temp;
                ballScript = ball.GetComponent<Ball>();
            }
            else if (Input.GetButtonUp("InitBall") && !ballInGame)
            {
                ballInGame = true;
                ballScript.Init();
            }
            else
            {
                if (ballScript.Position.y < paddleScript.Position.y - 0.5)
                {
                    ballInGame = false;
                    Destroy(ball);
                    lifeCount -= 1;
                    lifeSpriteRenderers[lifeCount].enabled = false;
                    if (lifeCount == 0)
                    {
                        Debug.Log("GameOver");
                    }
                }

                if (!ballInGame)
                {
                    float y = ballScript.Position.y;
                    ballScript.Position = new Vector2(paddleScript.Position.x, y);
                }
            }
        }
    }
}