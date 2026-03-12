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
            Debug.LogError("ФИНИШ!!!");
            _context.LoadingScreen.Show();
        }

        public void Exit()
        {

        }
    }
}