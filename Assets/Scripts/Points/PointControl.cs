using System;
using Object;
using UnityEngine;

namespace Points
{
    public class PointControl : MonoBehaviour
    {
        public string ObjectType { get; private set; }
        public GameObject Object { get; private set; }

        public event Action OnCheck;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Object"))
            {
                Object = other.gameObject;
                ObjectType = Object.GetComponent<ObjectExample>().ObjectIndex;
                print(ObjectType);
                OnCheck?.Invoke();
            }
        }
    }
}