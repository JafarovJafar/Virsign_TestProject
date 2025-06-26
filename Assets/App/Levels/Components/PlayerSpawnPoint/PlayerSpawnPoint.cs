using Shafir.EventBus;
using UnityEngine;
using Zenject;

namespace Virsign
{
    public class PlayerSpawnPoint : MonoBehaviour
    {
        [Inject] private ShafirEventBus _eventBus;

        private void Start()
        {
            _eventBus.Publish(new PlayerSpawnPointAppeared(this));
        }
    }
}