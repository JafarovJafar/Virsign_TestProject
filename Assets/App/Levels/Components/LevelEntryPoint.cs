using Shafir.EventBus;
using UnityEngine;
using Zenject;

namespace Virsign
{
    public class LevelEntryPoint : MonoBehaviour
    {
        [Inject] private ShafirEventBus _eventBus;

        private PlayerSpawnPoint _playerSpawnPoint;
        private GoalPoint _goalPoint;

        private void Awake()
        {
            _eventBus.Subscribe<PlayerSpawnPointAppeared>(OnPlayerSpawnPointAppeared);
            _eventBus.Subscribe<GoalPointAppeared>(OnGoalPointAppeared);
        }

        private void OnPlayerSpawnPointAppeared(PlayerSpawnPointAppeared message)
        {
            _playerSpawnPoint = message.Point;
            CheckIfIsFinished();
        }

        private void OnGoalPointAppeared(GoalPointAppeared message)
        {
            _goalPoint = message.Point;
            CheckIfIsFinished();
        }

        private void CheckIfIsFinished()
        {
            if (_playerSpawnPoint == null)
                return;

            if (_goalPoint == null)
                return;

            var message = new LevelElementsLoadFinished(_playerSpawnPoint, _goalPoint);
            _eventBus.Publish(message);
        }
    }
}