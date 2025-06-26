using System;
using Shafir.FSM;

namespace Virsign
{
    public class GameplayLoadLevelState : IState
    {
        public event Action Finished;

        private GameplayContext _context;

        public GameplayLoadLevelState(GameplayContext context)
        {
            _context = context;
        }

        public void Enter()
        {
            _context.SceneLoader.LoadSceneAdditive(2, null, OnLoadFinished);
        }

        public void Exit()
        {

        }

        private void OnLoadFinished()
        {
            Finished?.Invoke();
        }
    }
}