using Shafir.FSM;

namespace Virsign
{
    public class CubikDisappearState : IState
    {
        private CubikContext _context;

        public CubikDisappearState(CubikContext context)
        {
            _context = context;
        }

        public void Enter()
        {

        }

        public void Exit()
        {

        }
    }
}