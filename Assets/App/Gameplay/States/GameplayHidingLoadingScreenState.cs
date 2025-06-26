using System;
using Shafir.FSM;
using UnityEngine;

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
            _context.ForkLift.transform.position = Vector3.zero;
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