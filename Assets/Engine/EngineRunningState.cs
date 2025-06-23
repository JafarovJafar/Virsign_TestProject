using System;
using Shafir.FSM;

namespace Virsign
{
    internal class EngineRunningState : ITickableState
    {
        public event Action TurnOffRequested;

        private EngineContext _context;

        public EngineRunningState(EngineContext context)
        {
            _context = context;
        }

        public void Enter()
        {

        }

        public void Tick()
        {
            if (_context.Input.TurnOff.GetValue() == false)
                return;

            TurnOffRequested?.Invoke();
        }

        public void Exit()
        {

        }
    }
}