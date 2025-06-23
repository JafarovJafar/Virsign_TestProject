using System;
using Shafir.FSM;
using UnityEngine;

namespace Virsign
{
    internal class EngineTryingStartState : ITickableState
    {
        public event Action StartFailed;
        public event Action StartSucceeded;

        private EngineContext _context;

        private float _remainingTime;

        public EngineTryingStartState(EngineContext context)
        {
            _context = context;
        }

        public void Enter()
        {
            _remainingTime = _context.Stats.TimeForStart;
        }

        public void Tick()
        {
            if (_context.Input.Start.GetValue() == false)
                StartFailed?.Invoke();

            _remainingTime -= Time.deltaTime;

            if (_remainingTime > 0f)
                return;

            StartSucceeded?.Invoke();
        }

        public void Exit()
        {

        }
    }
}