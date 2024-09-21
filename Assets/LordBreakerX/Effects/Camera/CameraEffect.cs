using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.Utilities.Effects
{
    public abstract class CameraEffect : ScriptableObject
    {
        public abstract void InvokeEffect(Camera camera, Vector3 startPosition);
    }
}
