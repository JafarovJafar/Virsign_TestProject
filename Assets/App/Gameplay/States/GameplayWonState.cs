using System;
using Shafir.FSM;
using UnityEngine;

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
            Debug.LogError("entered WON STATE");
        }

        public void Exit()
        {

        }
    }
}