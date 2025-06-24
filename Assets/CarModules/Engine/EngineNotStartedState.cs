using System;
using Shafir.FSM;

namespace Virsign
{
    internal class EngineNotStartedState : ITickableState
    {
        public event Action StartRequested;

        private EngineContext _context;

        public EngineNotStartedState(EngineContext context)
        {
            _context = context;
        }

        public void Enter()
        {

        }

        public void Tick()
        {
            if (_context.Input.Start.GetValue() == false)
                return;

            StartRequested?.Invoke();
        }

        public void Exit()
        {

        }
    }
}