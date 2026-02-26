using System;
using Shafir.FSM;

namespace Virsign
{
    public class GameplayWonState : IState
    {
        public event Action Finished;

        private GameplayContext _context;

        public GameplayWonState(GameplayContext context)
        {
            _context = context;
        }

        public void Enter()
        {

        }

        public void Exit()
        {

        }
    }
}