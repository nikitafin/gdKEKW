using UnityEngine;

namespace Resources.Script
{
    public class PlayerController : MonoBehaviour
    {
        private Player playerScript;

        [SerializeField] [Header("Set vertical input axis")]
        private string verticalAxis;

        void Start()
        {
            playerScript = GetComponent<Player>();
            if (playerScript == null)
            {
                Debug.LogError("player script invalid");
            }
        }

        void Update()
        {
            playerScript.VerticalInput = Input.GetAxis(verticalAxis);
        }
    }
}