using System;
using Shafir.EventBus;
using UnityEngine;
using Zenject;

namespace Virsign
{
    /*
     TODO: возможно не нужен такой узконаправленный класс.
     Достаточно сделать TriggerFacade, а логику забирания расписать в GameplayMainState
     (подумать)
   */
    public class CubesCollector : MonoBehaviour
    {
        public event Action<Cubik> CaughtCubik;

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

            CaughtCubik?.Invoke(cubik);
        }
    }
}