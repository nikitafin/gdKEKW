using System;
using UnityEngine;
using UnityEngine.UI;

namespace Resources.Scripts
{
    public class GameController : MonoBehaviour
    {
        enum State
        {
            OnEnter,
            OnPlay,
            OnPause,
            OnGameOver
        }

        private LifesCounter lifesCounterScript;
        private Text greetingText;
        private Text startText;
        private Text pauseText;
        private Text resumeText;
        private Text gameOverText;


        private int score;
        private int lifes;
        [SerializeField] private State currentGameState;


        private void Awake()
        {
            lifesCounterScript = GetComponentInChildren<LifesCounter>();
            greetingText = GameObject.Find("GreetingText").GetComponent<Text>();
            startText = GameObject.Find("StartText").GetComponent<Text>();
            pauseText = GameObject.Find("PauseText").GetComponent<Text>();
            resumeText = GameObject.Find("ResumeText").GetComponent<Text>();
            gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();

            Time.timeScale = 0;
        }

        private void Start()
        {
            score = 0;
            lifes = 3;
            lifesCounterScript.SetLife(lifes);
            currentGameState = State.OnEnter;
        }

        private void Update()
        {
            if (currentGameState == State.OnPlay)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }

            if (Input.GetButtonDown("Start") && currentGameState == State.OnPlay)
            {
                SetOnPause();
            }
            else if (Input.GetButtonDown("Start") && currentGameState == State.OnPause)
            {
                SetOnPlay();
            }
            else if (Input.GetButtonDown("Start") && currentGameState == State.OnEnter)
            {
                SetOnPlay();
            }
            else if (Input.GetButtonDown("Start") && currentGameState == State.OnGameOver)
            {
                Start();
                SetOnPlay();
            }
        }

        private void SetOnPlay()
        {
            currentGameState = State.OnPlay;
            greetingText.enabled = false;
            startText.enabled = false;
            pauseText.enabled = false;
            resumeText.enabled = false;
            gameOverText.enabled = false;
        }


        private void SetOnPause()
        {
            currentGameState = State.OnPause;
            pauseText.enabled = true;
            resumeText.enabled = true;
        }

        private void SetGameOver()
        {
            currentGameState = State.OnGameOver;
            gameOverText.enabled = true;
            startText.enabled = true;
        }

        public void MisFruit()
        {
            lifes -= 1;
            if (lifes == 0)
            {
                SetGameOver();
            }

            GameObject[] allFruits = GameObject.FindGameObjectsWithTag("Fruit");
            foreach (var fruit in allFruits)
            {
                Destroy(fruit);
            }

            lifesCounterScript.SetLife(lifes);
        }


        public int Score
        {
            get => score;
            set => score = value;
        }
    }
}