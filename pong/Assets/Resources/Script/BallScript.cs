using UnityEngine;


namespace Resources.Script
{
    public class BallScript : MonoBehaviour
    {
        Rigidbody2D rbody2d;
        public float x;

        void Awake()
        {
            rbody2d = GetComponent<Rigidbody2D>();
        }
        void Start()
        {
            Random.InitState(System.Environment.TickCount);

            int temp = Random.Range(-1, 1);

            rbody2d.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
        }

        void FixedUpdate()
        {
            if (GameSate.CurrentSate == State.Play)
            {
            }
        }
    }
}