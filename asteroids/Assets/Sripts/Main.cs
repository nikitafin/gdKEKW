using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sripts
{
    public class Main : MonoBehaviour
    {
        public Sprite[] bigSprites;
        public Sprite[] mediumSprites;
        public Sprite[] smallSprites;

        public GameObject asteroidPrefab;

        private GameLevel currentLevel = GameLevel.First;
        private Dictionary<AsteroidSize, Sprite[]> asteroidSizeToSprite = new Dictionary<AsteroidSize, Sprite[]>();

        private void Start()
        {
            // Save various of asteroid types in dict,
            if (bigSprites != null)
            {
                asteroidSizeToSprite.Add(AsteroidSize.Large, bigSprites);
            }

            if (mediumSprites != null)
            {
                asteroidSizeToSprite.Add(AsteroidSize.Medium, mediumSprites);
            }

            if (smallSprites != null)
            {
                asteroidSizeToSprite.Add(AsteroidSize.Small, smallSprites);
            }

            // Todo: Change asteroid counts and position to depend on level config
            // for now generate 4 asteroid like in classic game
            GenerateAsteroid(AsteroidSize.Large);
            GenerateAsteroid(AsteroidSize.Large);
            GenerateAsteroid(AsteroidSize.Large);
            GenerateAsteroid(AsteroidSize.Large);
        }

        private void GenerateAsteroid(AsteroidSize asteroidSize)
        {
            // x < 0.3 or x > 0.7
            // don't allow generate asteroid close to ship
            float randX = Random.Range(0.0f, 1.0f) > 0.5f ? Random.Range(0.0f, 0.3f) : Random.Range(0.7f, 1.0f);
            //
            float randY = Random.Range(0.0f, 1.0f);

            Vector2 randomPositionOnScreen =
                Camera.main.ViewportToWorldPoint(new Vector2(randX, randY));

            var tempAsteroid = Instantiate(asteroidPrefab,
                randomPositionOnScreen,
                quaternion.identity).GetComponent<Asteroid>();
            // Set size and init sprite cause of this size
            tempAsteroid.AsterdSize = asteroidSize;
            tempAsteroid.InitSpite();
        }


        #region Properties

        public GameLevel CurrentLevel
        {
            get => currentLevel;
            set => currentLevel = value;
        }

        public Dictionary<AsteroidSize, Sprite[]> AsteroidSizeToSprite => asteroidSizeToSprite;

        #endregion
    }
}