using System;
using Shafir.EventBus;
using UnityEngine;
using Zenject;

namespace Virsign
{
    public class CubesCollector : MonoBehaviour
    {
        public event Action<Cubik> CatchedCubik;

        [SerializeField] private TriggerHelper trigger;

        [Inject] private ShafirEventBus _eventBus;

        private void Awake()
        {
            _eventBus.Publish(new CubesCollectorAppeared(this));

            trigger.Entered += OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            if (collider.TryGetComponent(out Cubik cubik) == false)
            {
                return;
            }

            CatchedCubik?.Invoke(cubik);
        }
    }
}