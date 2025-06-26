using Shafir.EventBus;
using UnityEngine;
using Zenject;

namespace Virsign
{
    public class LevelEntryPoint : MonoBehaviour
    {
        [Inject] private ShafirEventBus _eventBus;

        private PlayerSpawnPoint _playerSpawnPoint;
        private CubesSpawnPoint _cubesSpawnPoint;

        private void Awake()
        {
            _eventBus.Subscribe<PlayerSpawnPointAppeared>(OnPlayerSpawnPointAppeared);
            _eventBus.Subscribe<CubesSpawnPointAppeared>(OnGoalPointAppeared);
        }

        private void OnPlayerSpawnPointAppeared(PlayerSpawnPointAppeared message)
        {
            _playerSpawnPoint = message.Point;
            CheckIfIsFinished();
        }

        private void OnGoalPointAppeared(CubesSpawnPointAppeared message)
        {
            _cubesSpawnPoint = message.Point;
            CheckIfIsFinished();
        }

        private void CheckIfIsFinished()
        {
            if (_playerSpawnPoint == null)
                return;

            if (_cubesSpawnPoint == null)
                return;

            var message = new LevelElementsLoadFinished(_playerSpawnPoint, _cubesSpawnPoint);
            _eventBus.Publish(message);
        }
    }
}