using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.Utilities.Effects
{
    public class CameraEffectHandler : MonoBehaviour
    {
        [System.Serializable]
        public struct Effect
        {
            [SerializeField]
            private string _identifer;
            [SerializeField]
            private CameraEffect _effectSO;

            public string Identifer { get { return _identifer; } }
            public CameraEffect EffectSO { get { return _effectSO; } }

            public Effect(string identifer, CameraEffect effect)
            {
                _identifer = identifer;
                _effectSO = effect;
            }
        }

        [SerializeField] private Camera _effectCamera;
        [SerializeField] private Effect[] effects;
        
        public void ActivateEffect(string effectIdentifer)
        {
            CameraEffect effect = GetEffect(effectIdentifer);

            if (effect != null)
            {
                effect.InvokeEffect(_effectCamera, _effectCamera.transform.position);
            }
            else
            {
                Debug.LogError($"There is no effect with the identifer: {effectIdentifer}");
            }
        }

        private CameraEffect GetEffect(string effectIdentifer)
        {
            foreach (Effect effect in effects)
            {
                if (effect.Identifer == effectIdentifer)
                {
                    return effect.EffectSO;
                }
            }
            return null;
        }
    }
}
