using UnityEngine;

namespace Resources.Scripts
{
    public class Init : MonoBehaviour
    {
        private void Awake()
        {
            ScreenWrapper.Init();
        }
    }
}