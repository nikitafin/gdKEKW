using UnityEngine;
using Random = UnityEngine.Random;

namespace Sripts
{
    public class Asteroid : MonoBehaviour
    {
        private GameObject mainObject;
        private Main mainScript;
        private AsteroidSpawner asteroidSpawnerScript;

        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rg2D;
        private AsteroidSize asteroidSize;

        // physics
        private Vector2 thrustDirection;
        private const float ThrustMagnitude = 10f;
        private const float MaxSpeed = 5.45f;

        #region UnityBase

        private void Awake()
        {
            mainObject = GameObject.Find("Main");
            mainScript = mainObject.GetComponent<Main>();
            asteroidSpawnerScript = mainObject.GetComponent<AsteroidSpawner>();
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            rg2D = gameObject.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            // limit velocity
            Vector2 tempVelocity = rg2D.velocity;
            tempVelocity.x = Mathf.Clamp(tempVelocity.x, -MaxSpeed, MaxSpeed);
            tempVelocity.y = Mathf.Clamp(tempVelocity.y, -MaxSpeed, MaxSpeed);
            rg2D.velocity = tempVelocity;

            // slightly tune direction
            if (Random.value > 0.90f)
            {
                rg2D.rotation += Random.Range(-0.125f, 0.125f);
            }

            // wrap 
            ScreenWrapper.Wrap(gameObject);
        }

        #endregion

        #region OwnBaseFuncs

        /// <summary>
        /// Basic setup asteroid object
        /// Sets size of asteroid, set sprite, generate direction and add force
        /// </summary>
        /// <param name="size">Size of Asteroid</param>
        public void Init(AsteroidSize size)
        {
            // set size
            asteroidSize = size;
            // set spite
            spriteRenderer.sprite =
                mainScript.AsteroidSizeToSprite[size][
                    Random.Range(0, mainScript.AsteroidSizeToSprite[size].Length)];
            gameObject.name = "Asteroid";
        }

        public void RandomDirectionAndForce()
        {
            // set direction, add force
            thrustDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rg2D.AddForce(new Vector2(Random.Range(1, 5), Random.Range(1, 5)) * thrustDirection * ThrustMagnitude,
                ForceMode2D.Impulse);
        }

        public void RandomForce(Vector2 direction)
        {
            thrustDirection = direction;
            rg2D.AddForce(new Vector2(Random.Range(1, 5), Random.Range(1, 5)) * thrustDirection * ThrustMagnitude,
                ForceMode2D.Impulse);
        }

        public void Destruction()
        {
            if (asteroidSize == AsteroidSize.Large)
            {
                asteroidSpawnerScript.GenerateSmallerAsteroids(AsteroidSize.Medium, transform.position,
                    transform.rotation, rg2D.velocity);
            }
            else if (asteroidSize == AsteroidSize.Medium)
            {
                asteroidSpawnerScript.GenerateSmallerAsteroids(AsteroidSize.Small, transform.position,
                    transform.rotation, rg2D.velocity);
            }

            Destroy(gameObject);
        }

        #endregion

        #region Properties

        public Vector2 ThrustDirection { get; set; }

        #endregion
    }
}