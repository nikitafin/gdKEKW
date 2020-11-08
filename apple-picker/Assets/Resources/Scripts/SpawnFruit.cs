using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Resources.Scripts
{
    public class SpawnFruit : MonoBehaviour
    {
        private Transform[] spawns;

        [SerializeField] private GameObject[] fruitPrefabs;


        private Rigidbody2D rd2D;
        private BoxCollider2D bc2d;
        private float xVelocity = 3f;
        private float halfWidth, halfHeight;


        private void Awake()
        {
            spawns = GetComponentsInChildren<Transform>();
            if (spawns == null)
            {
                Debug.LogError("No spawns");
            }

            if (fruitPrefabs == null)
            {
                Debug.LogError("No prefabs");
            }

            rd2D = GetComponent<Rigidbody2D>();
            bc2d = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            var bounds = bc2d.bounds;
            halfWidth = bounds.extents.x;
            halfHeight = bounds.extents.y;
            Invoke(nameof(DropFruit), 2.5f);
        }

        private void DropFruit()
        {
            int randSpawnIndex = Random.Range(0, spawns.Length);
            int randFruitIndex = Random.Range(0, fruitPrefabs.Length);
            Instantiate(fruitPrefabs[randFruitIndex], spawns[randSpawnIndex].position,
                spawns[randSpawnIndex].rotation);

            Invoke(nameof(DropFruit), 1f);
        }

        private void FixedUpdate()
        {
            Vector2 newPos = rd2D.position + Vector2.right * (xVelocity * Time.fixedDeltaTime);
            newPos.x = Mathf.Clamp(newPos.x, ScreenWrapper.ScreenLeft + halfWidth,
                ScreenWrapper.ScreenRight - halfWidth);

            if (Math.Abs(newPos.x - (ScreenWrapper.ScreenLeft + halfWidth)) < 0.00001 ||
                Math.Abs(newPos.x - (ScreenWrapper.ScreenRight - halfWidth)) < 0.00001)
            {
                xVelocity = -xVelocity;
            }

            rd2D.MovePosition(newPos);
        }
    }
}