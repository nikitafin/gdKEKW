using UnityEngine;

namespace Resources.Script
{
    public class GameController : MonoBehaviour
    {

        int FirstPlayerScore { get; set; }
        int SecondPlayerScore { get; set; }
        void Start()
        {
            GameSate.Init();
            FirstPlayerScore = 0;
            SecondPlayerScore = 0;
        }

        void Update()
        {
            if (Input.GetButtonDown("Startbtn"))
            {
                if (GameSate.CurrentSate == State.Start)
                {
                    StartGame();
                }
                else if (GameSate.CurrentSate == State.Play)
                {
                    PauseGame();
                }
                else
                {
                    ContinueGame();
                }
            }
        }

        #region Methods
        void StartGame()
        {
            GameSate.CurrentSate = State.Play;
        }
        void PauseGame()
        {
            GameSate.CurrentSate = State.Pause;
            Time.timeScale = 0f;
        }

        void ContinueGame()
        {
            GameSate.CurrentSate = State.Play;
            Time.timeScale = 1f;
        }
        #endregion
    }
}
