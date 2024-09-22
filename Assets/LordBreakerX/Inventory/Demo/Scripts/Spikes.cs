using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX
{
    public class Spikes : MonoBehaviour
    {
        [SerializeField]
        [Min(0f)]
        private float _timeBetweenDamage = 1;

        [SerializeField]
        private int _damage;

        private bool withinSpike = false;

        private float _nextDamage;

        private void Update()
        {
            if (withinSpike)
            {
                if (_nextDamage <= 0)
                {
                    _nextDamage = _timeBetweenDamage;
                    Player.Instance.Damage(_damage);
                }
                else
                {
                    _nextDamage -= Time.deltaTime;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _nextDamage = _timeBetweenDamage;
                withinSpike = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                withinSpike = false;
            }
        }
    }
}
