using System;
using Shafir.FSM;
using UnityEngine;

namespace Virsign
{
    public class GameplayMainState : IState
    {
        public event Action Won;

        private GameplayContext _context;

        private int _counter;

        public GameplayMainState(GameplayContext context)
        {
            _context = context;
        }

        public void Enter()
        {
            _context.InputAdapter.SetForkLift(_context.ForkLift);
            _context.InputAdapter.Activate();

            _context.CubesCollector.CaughtCubik += OnCaughtCubik;

            _counter = _context.CubesSpawnPoint.SpawnData.Count;
        }

        public void Exit()
        {
            _context.InputAdapter.DeActivate();
        }

        private void OnCaughtCubik(Cubik cubik)
        {
            cubik.FlyAway();
            
            _counter--;

            Debug.LogError($"new counter = {_counter}");

            if (_counter > 0)
                return;

            Won?.Invoke();
        }
    }
}