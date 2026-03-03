using Shafir.FSM;
using UnityEngine;

namespace Virsign
{
    public class Engine : MonoBehaviour
    {
        public EngineInput Input => _input;
        public EventField<bool> IsRunning => _isRunning;
        public EventField<float> CurrentRpm => _currentRpm;
        public float MinRpm => stats.MinRpm;
        public float MaxRpm => stats.MaxRpm;

        [SerializeField] private EngineStats stats;
        [SerializeField] private WheelCollider[] wheels;

        private EventField<bool> _isRunning;
        private EventField<float> _currentRpm;

        private EngineInput _input;

        private TickableStateMachine _stateMachine;
        private EngineContext _context;
        private EngineNotStartedState _notStartedState;
        private EngineTryingStartState _tryingStartState;
        private EngineRunningState _runningState;

        public void Initialize()
        {
            _isRunning = new();
            _currentRpm = new();

            _input = new EngineInput();

            _context = new()
            {
                Input = _input,
                Stats = stats,
                CurrentRpm = _currentRpm,
                IsRunning = _isRunning,
                Wheels = wheels,
            };

            _notStartedState = new EngineNotStartedState(_context);
            _notStartedState.StartRequested += OnStartRequested;
            _tryingStartState = new EngineTryingStartState(_context);
            _tryingStartState.StartSucceeded += OnStartSucceeded;
            _tryingStartState.StartFailed += OnStartFailed;
            _runningState = new EngineRunningState(_context);
            _runningState.TurnOffRequested += OnTurnOffRequested;

            _stateMachine = new TickableStateMachine();
            _stateMachine.ChangeState(_notStartedState);
        }

        private void OnStartRequested()
        {
            _stateMachine.ChangeState(_tryingStartState);
        }

        private void OnStartSucceeded()
        {
            _stateMachine.ChangeState(_runningState);
        }

        private void OnStartFailed()
        {
            _stateMachine.ChangeState(_notStartedState);
        }

        private void OnTurnOffRequested()
        {
            _stateMachine.ChangeState(_notStartedState);
        }

        private void Update()
        {
            _stateMachine.Tick();
        }
    }
}