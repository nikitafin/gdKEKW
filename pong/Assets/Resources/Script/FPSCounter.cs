using UnityEngine;
using UnityEngine.UI;

namespace Resources.Script
{
    public class FPSCounter : MonoBehaviour
    {
        [Header("Set Frame Rate")] [SerializeField]
        private int frameRate;

        private Text fpsDisplay;

        private void Awake()
        {
            fpsDisplay = GameObject.Find("FpsCounterText").GetComponent<Text>();
        }

        private void Start()
        {
            frameRate = 300;
            Application.targetFrameRate = frameRate;
        }

        private void Update()
        {
            float fps = 1 / Time.unscaledDeltaTime;
            fpsDisplay.text = "FPS: " + fps;
        }

        private void OnValidate()
        {
            Application.targetFrameRate = frameRate;
        }
    }
}