using UnityEngine;

namespace Resources.Script
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D rb;

        private float verticalInput = 0f;

        [SerializeField] private float verticalVelocity = 100f;


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(0, verticalInput * verticalVelocity);
        }


        #region Properties

        public float VerticalInput
        {
            get => verticalInput;
            set => verticalInput = value;
        }

        #endregion
    }
}