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
            _context.IsRunning.SetValue(false);
            _context.CurrentRpm.SetValue(0f);
        }

        public void Tick()
        {
            if (_context.Input.Start.Value == false)
                return;

            StartRequested?.Invoke();
        }

        public void Exit()
        {

        }
    }
}