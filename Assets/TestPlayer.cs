using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LordBreakerX
{
    public class TestPlayer : MonoBehaviour
    {
        [SerializeField]
        private int startHealth = 10;
        public int Health { get; set; }

        [SerializeField]
        public TMP_Text text;

        private void Awake()
        {
            Health = startHealth;
            text.text = Health.ToString();
        }
    }
}
