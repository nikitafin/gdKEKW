using UnityEngine;

namespace Resources.Script
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D rigidBody;
        private BoxCollider2D boxCollider;

        private float verticalInput = 0f;
        private float halfWidth;
        private float halfHeight;


        [SerializeField] private float verticalVelocity = 100f;


        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            boxCollider = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            var bounds = boxCollider.bounds.extents;
            halfWidth = bounds.x;
            halfHeight = bounds.y;
        }

        private void FixedUpdate()
        {
            Vector2 newPosition =
                rigidBody.position + Vector2.up * (verticalInput * verticalVelocity * Time.fixedDeltaTime);
            // stay new position in camera view
            newPosition.x = Mathf.Clamp(newPosition.x, ScreenWrapper.ScreenLeft + halfWidth,
                ScreenWrapper.ScreenRight - halfWidth);
            newPosition.y = Mathf.Clamp(newPosition.y, ScreenWrapper.ScreenBottom + halfHeight,
                ScreenWrapper.ScreenTop - halfHeight);

            rigidBody.MovePosition(newPosition);
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