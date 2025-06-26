using System;
using UnityEngine;

namespace Virsign
{
    public class TriggerHelper : MonoBehaviour
    {
        public event Action<Collider> Entered;
        public event Action<Collider> Staying;
        public event Action<Collider> Exit;

        [SerializeField] private Collider collider;

        public void Enable()
        {
            collider.enabled = true;
        }

        public void Disable()
        {
            collider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            Entered?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            Staying?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            Exit?.Invoke(other);
        }
    }
}