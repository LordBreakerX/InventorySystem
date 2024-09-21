using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.Objects
{
    public class ObjectManager : MonoBehaviour
    {
        [System.Serializable]
        public struct LookupObject
        {
            public string identifer;
            public GameObject obj;

            public LookupObject(string identifer, GameObject obj)
            {
                this.identifer = identifer;
                this.obj = obj;
            }
        }

        [SerializeField]
        private List<LookupObject> _lookupObjects;

        private static Dictionary<string, GameObject> _registryObjects = new Dictionary<string, GameObject>();

        public static IReadOnlyDictionary<string, GameObject> RegistryObjects { get { return _registryObjects; } } 

        private void Awake()
        {
            foreach (LookupObject lookupObject in _lookupObjects)
            {
                _registryObjects.Add(lookupObject.identifer, lookupObject.obj);
            }
        }

    }
}
