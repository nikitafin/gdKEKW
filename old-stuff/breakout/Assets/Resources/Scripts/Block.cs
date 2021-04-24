using UnityEngine;

namespace Resources.Scripts
{
    public class Block : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                Destroy(gameObject);
            }
        }
    }
}