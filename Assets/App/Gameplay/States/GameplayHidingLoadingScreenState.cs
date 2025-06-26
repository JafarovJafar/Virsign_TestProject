using System;
using Shafir.FSM;

namespace Virsign
{
    public class GameplayHidingLoadingScreenState : IState
    {
        public event Action Finished;

        private GameplayContext _context;

        public GameplayHidingLoadingScreenState(GameplayContext context)
        {
            _context = context;
        }

        public void Enter()
        {
            var spawnPointTransform = _context.PlayerSpawnPoint.transform;
            var finalPos = spawnPointTransform.position;
            var finalRot = spawnPointTransform.rotation;
            _context.ForkLift.transform.SetPositionAndRotation(finalPos, finalRot);
            _context.ForkLift.Activate();

            _context.LoadingScreen.Hide(OnHideFinished);
            _context.Camera.SetTarget(_context.ForkLift.transform);
        }

        public void Exit()
        {

        }

        private void OnHideFinished()
        {
            Finished?.Invoke();
        }
    }
}