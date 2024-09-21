using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.Utilities.Effects
{
    public class CameraBobbingEffect : CameraEffect
    {
        [SerializeField]
        private float bobSpeed;

        [SerializeField]
        private float bobAmount;

        private float timer = 0;

        public override void InvokeEffect(Camera camera, Vector3 startPosition)
        {
            //if (Mathf.Abs(controller.PlayerBody.velocity.x) > 0.1f || Mathf.Abs(controller.PlayerBody.velocity.z) > 0.1f)
            //{
            //    timer += Time.deltaTime * bobSpeed;
            //    camera.transform.position = new Vector3(startPosition.x, startPosition.y + Mathf.Sin(timer) * bobAmount, startPosition.z);
            //}
            //else
            //{
            //    timer = 0;
            //    camera.transform.position = new Vector3(startPosition.x, Mathf.Lerp(camera.transform.position.y, startPosition.y, Time.deltaTime * bobSpeed), startPosition.z);
            //}
        }
    }
}
