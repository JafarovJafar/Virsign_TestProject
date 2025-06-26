using System;
using Shafir.FSM;

namespace Virsign
{
    public class GameplayLoadLevelState : IState
    {
        public event Action Finished;

        private GameplayContext _context;

        private bool _isLevelLoad;

        public GameplayLoadLevelState(GameplayContext context)
        {
            _context = context;
        }

        public void Enter()
        {
            _isLevelLoad = false;
            _context.EventBus.Subscribe<PlayerSpawnPointAppeared>(OnPlayerSpawnPointAppeared);
            _context.EventBus.Subscribe<CubesSpawnPointAppeared>(OnGoalPointAppeared);

            _context.SceneLoader.LoadSceneAdditive(2, null, OnLoadFinished);
        }

        public void Exit()
        {
            _context.EventBus.UnSubscribe<PlayerSpawnPointAppeared>(OnPlayerSpawnPointAppeared);
            _context.EventBus.UnSubscribe<CubesSpawnPointAppeared>(OnGoalPointAppeared);
        }

        private void OnPlayerSpawnPointAppeared(PlayerSpawnPointAppeared message)
        {
            _context.PlayerSpawnPoint = message.Point;
        }

        private void OnGoalPointAppeared(CubesSpawnPointAppeared message)
        {
            _context.CubesSpawnPoint = message.Point;
        }

        private void OnLoadFinished()
        {
            _isLevelLoad = true;
            CheckIfIsFinished();
        }

        private void CheckIfIsFinished()
        {
            if (_isLevelLoad == false)
                return;

            if (_context.PlayerSpawnPoint == null)
                return;

            if (_context.CubesSpawnPoint == null)
                return;

            Finished?.Invoke();
        }
    }
}