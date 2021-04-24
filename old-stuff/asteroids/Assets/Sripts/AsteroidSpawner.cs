using UnityEngine;

namespace Sripts
{
    public class AsteroidSpawner : MonoBehaviour
    {
        public GameObject asteroidPrefab;

        public void GenerateSmallerAsteroids(AsteroidSize size, Vector2 pos, Quaternion rot, Vector2 vel)
        {
            if (asteroidPrefab == null)
            {
                return;
            }

            Vector2[] directions =
            {
                new Vector2(-1, 1),
                new Vector2(1, 1),
                new Vector2(-1, -1),
                new Vector2(1, -1)
            };
            foreach (var direction in directions)
            {
                // create new smaller asteroid. init and gen force
                var temp = Instantiate(asteroidPrefab, pos, rot).GetComponent<Asteroid>();
                temp.Init(size);
                temp.RandomForce(direction);
            }
        }
    }
}