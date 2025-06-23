using Shafir.FSM;
using UnityEngine;

namespace Virsign
{
    public class Engine : MonoBehaviour
    {
        public EngineInput Input => _input;
        public bool IsRunning => _isRunning;

        [SerializeField] private EngineStats stats;

        private EngineInput _input;

        private TickableStateMachine _stateMachine;
        private EngineContext _context;
        private EngineNotStartedState _notStartedState;
        private EngineTryingStartState _tryingStartState;
        private EngineRunningState _runningState;

        private bool _isRunning;

        public void Initialize()
        {
            _input = new EngineInput();

            _context = new()
            {
                Input = _input,
                Stats = stats,
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

        private void OnStartRequested() => _stateMachine.ChangeState(_tryingStartState);

        private void OnStartSucceeded()
        {
            _stateMachine.ChangeState(_runningState);
            _isRunning = true;
        }

        private void OnStartFailed()
        {
            _stateMachine.ChangeState(_notStartedState);
            _isRunning = false;
        }

        private void OnTurnOffRequested()
        {
            _stateMachine.ChangeState(_notStartedState);
            _isRunning = false;
        }

        private void Update()
        {
            _stateMachine.Tick();
        }
    }
}