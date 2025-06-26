using System;
using Shafir.FSM;

namespace Virsign
{
    public class GameplayMainState : IState
    {
        public event Action Won;
        
        private GameplayContext _context;

        public GameplayMainState(GameplayContext context)
        {
            _context = context;
        }

        public void Enter()
        {
            _context.InputAdapter.Activate();
        }

        public void Exit()
        {

        }
    }
}