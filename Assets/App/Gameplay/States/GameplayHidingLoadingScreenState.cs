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
            _context.LoadingScreen.Hide(OnHideFinished);
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