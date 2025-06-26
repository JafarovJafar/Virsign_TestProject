using Shafir.FSM;
using UnityEngine;
using Zenject;

namespace Virsign
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [Inject] private SceneLoader _sceneLoader;
        [Inject] private ForkLift _forkLift;
        [Inject] private ForkLiftKeyboardInputAdapter _inputAdapter;
        [Inject] private LoadingScreen _loadingScreen;

        private SimpleStateMachine _stateMachine;
        private GameplayContext _context;
        private GameplayLoadLevelState _loadLevelState;
        private GameplayHidingLoadingScreenState _hidingLoadingScreenState;
        private GameplayMainState _mainState;
        private GameplayWonState _wonState;
        private GameplayShowingLoadingScreenState _showingLoadingScreenState;

        private void Start()
        {
            _forkLift.DeActivate();

            _inputAdapter.SetForkLift(_forkLift);
            _inputAdapter.DeActivate();

            _stateMachine = new SimpleStateMachine(Debug.Log);

            _context = new()
            {
                SceneLoader = _sceneLoader,
                ForkLift = _forkLift,
                InputAdapter = _inputAdapter,
                LoadingScreen = _loadingScreen,
            };

            _loadLevelState = new(_context);
            _loadLevelState.Finished += OnLoadLevelFinished;
            _hidingLoadingScreenState = new(_context);
            _hidingLoadingScreenState.Finished += OnLoadingScreenHidden;
            _mainState = new(_context);
            _mainState.Won += OnWon;
            _wonState = new(_context);
            _wonState.Finished += OnWinFinished;
            _showingLoadingScreenState = new(_context);
            _showingLoadingScreenState.Finished += OnLoadingScreenShown;

            _stateMachine.ChangeState(_loadLevelState);
        }

        private void OnLoadLevelFinished() => _stateMachine.ChangeState(_hidingLoadingScreenState);
        private void OnLoadingScreenHidden() => _stateMachine.ChangeState(_mainState);
        private void OnWon() => _stateMachine.ChangeState(_wonState);
        private void OnWinFinished() => _stateMachine.ChangeState(_showingLoadingScreenState);
        private void OnLoadingScreenShown() => _stateMachine.ChangeState(_loadLevelState);
    }
}