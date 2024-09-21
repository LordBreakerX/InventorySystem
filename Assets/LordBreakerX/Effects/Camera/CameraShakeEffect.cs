using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace LordBreakerX.Utilities.Effects
{
    public class CameraShakeEffect : CameraEffect
    {
        [SerializeField]
        private float duration = 1f;

        [SerializeField]
        private AnimationCurve shakeCurve = AnimationCurve.Linear(0, 0, 1, 0);

        public async override void InvokeEffect(Camera camera, Vector3 startPosition)
        {
            float elapsedTime = 0f;
            float strength;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                strength = shakeCurve.Evaluate(elapsedTime / duration);
                camera.transform.position = startPosition + Random.insideUnitSphere * strength;
                await Task.Yield();
            }

            camera.transform.position = startPosition;
        }
    }
}
