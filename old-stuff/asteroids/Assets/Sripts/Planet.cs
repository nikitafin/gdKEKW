using UnityEngine;

namespace Sripts
{
    public class Planet : MonoBehaviour
    {
        public Sprite[] spriteType;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteType.Length != 0)
            {
                var rnd = new System.Random();
                spriteRenderer.sprite = spriteType[rnd.Next(0, spriteType.Length - 1)];
            }
        }
    }
}