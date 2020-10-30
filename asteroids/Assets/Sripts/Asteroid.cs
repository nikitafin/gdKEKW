using System;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sripts
{
    public class Asteroid : MonoBehaviour
    {
        private GameObject mainObject;
        private Main mainScript;

        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rg2D;
        private AsteroidSize asterdSize;
        private Vector2 thrustDirection;
        private const float ThrustMagnitude = 10f;
        private const float MaxSpeed = 5.45f;

        public void InitSpite()
        {
            if (AsterdSize != AsteroidSize.None)
            {
                spriteRenderer.sprite =
                    mainScript.AsteroidSizeToSprite[asterdSize][
                        Random.Range(0, mainScript.AsteroidSizeToSprite[asterdSize].Length)];
            }
        }

        private void Awake()
        {
            mainObject = GameObject.Find("Main");
            mainScript = mainObject.GetComponent<Main>();

            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            rg2D = gameObject.GetComponent<Rigidbody2D>();

            thrustDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rg2D.AddForce(thrustDirection * ThrustMagnitude, ForceMode2D.Impulse);
            // velocity = new Vector2(Random.value * MaxSpeed, Random.value * MaxSpeed);
        }

        private void FixedUpdate()
        {
            // limit velocity
            Vector2 tempVelocity = rg2D.velocity;
            tempVelocity.x = Mathf.Clamp(tempVelocity.x, -MaxSpeed, MaxSpeed);
            tempVelocity.y = Mathf.Clamp(tempVelocity.y, -MaxSpeed, MaxSpeed);
            rg2D.velocity = tempVelocity;

            // slightly tune direction
            if (Random.value > 0.95f)
            {
                rg2D.rotation += Random.Range(-0.125f, 0.125f);
            }

            ScreenWrapper.Wrap(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                Destroy(gameObject);
                other.gameObject.GetComponent<Bullet>().Destrucion();
            }
        }

        #region Properties

        public AsteroidSize AsterdSize { get; set; }
        public Vector2 Direction { get; set; }

        #endregion
    }
}