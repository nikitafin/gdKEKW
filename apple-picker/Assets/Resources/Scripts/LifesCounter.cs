using System;
using UnityEngine;

namespace Resources.Scripts
{
    public class LifesCounter : MonoBehaviour
    {
        [Header("Dynamic load")] [SerializeField]
        private Sprite[] lifes;

        private SpriteRenderer sr;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
        }

        void Start()
        {
            lifes = new Sprite[4];
            lifes[0] = UnityEngine.Resources.Load<Sprite>("Assets/HUD/0");
            lifes[1] = UnityEngine.Resources.Load<Sprite>("Assets/HUD/2");
            lifes[2] = UnityEngine.Resources.Load<Sprite>("Assets/HUD/4");
            lifes[3] = UnityEngine.Resources.Load<Sprite>("Assets/HUD/6");
        }

        public void SetLife(int idx)
        {
            if (idx > lifes.Length || idx < 0)
            {
                return;
            }

            sr.sprite = lifes[idx];
        }
    }
}