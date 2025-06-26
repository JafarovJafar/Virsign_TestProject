using System;
using Shafir.FSM;

namespace Virsign
{
    public class GameplayShowingLoadingScreenState : IState
    {
        public event Action Finished;
        
        private GameplayContext _context;

        public GameplayShowingLoadingScreenState(GameplayContext context)
        {
            _context = context;
        }
        
        public void Enter()
        {
            _context.LoadingScreen.Show(OnShowFinished);
        }

        public void Exit()
        {

        }

        private void OnShowFinished()
        {
            Finished?.Invoke();
        }
    }
}