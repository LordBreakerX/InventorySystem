using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX
{
    [CreateAssetMenu()]
    public class ShotgunItem : GunItem
    {
        [SerializeField]
        private int pelletsPerShot;

        [SerializeField]
        private bool hasKickback;

        [SerializeField]
        private float kickbackStrength;
    }
}
