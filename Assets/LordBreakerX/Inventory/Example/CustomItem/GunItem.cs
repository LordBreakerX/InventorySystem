using LordBreakerX.Inventory;

using UnityEngine;

namespace LordBreakerX
{
    [CreateAssetMenu()]
    public class GunItem : Item
    {
        [SerializeField]
        private float _projectileSpeed;
        [SerializeField]
        private float _projectileRange;

        [SerializeField]
        private float _damage;

        [SerializeField]
        private float _reloadTime;

        [SerializeField]
        private int clipSize;

        [SerializeField]
        private int maxClips;
    }
}
