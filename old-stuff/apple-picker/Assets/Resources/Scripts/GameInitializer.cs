using UnityEngine;

namespace Resources.Scripts
{
    public class GameInitializer : MonoBehaviour
    {
        private void Awake()
        {
            ScreenWrapper.Init();
        }
    }
}