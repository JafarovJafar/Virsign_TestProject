using System;
using Shafir.FSM;
using UnityEngine;

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
            _context.IsRunning.SetValue(true);
        }

        public void Tick()
        {
            if (_context.Input.TurnOff.GetValue() == true)
            {
                TurnOffRequested?.Invoke();
                return;
            }

            var currentRpm = _context.CurrentRpm.GetValue();
            var gasRatio = _context.Input.GasRatio.GetValue();

            if (Mathf.Approximately(gasRatio, 0f))
            {
                var delta = _context.Stats.Deceleration * Time.deltaTime;
                currentRpm = Mathf.MoveTowards(currentRpm, 0f, delta);
                _context.CurrentRpm.SetValue(currentRpm);
                return;
            }

            var finalDelta = gasRatio;
            finalDelta *= _context.Stats.Acceleration;
            finalDelta *= Time.deltaTime;
            currentRpm += finalDelta;
            currentRpm = Mathf.Clamp(currentRpm, _context.Stats.MinRpm, _context.Stats.MaxRpm);
            _context.CurrentRpm.SetValue(currentRpm);
        }

        public void Exit()
        {

        }
    }
}