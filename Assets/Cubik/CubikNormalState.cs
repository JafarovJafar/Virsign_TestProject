using Shafir.FSM;

namespace Virsign
{
    public class CubikNormalState : IState
    {
        private CubikContext _context;

        public CubikNormalState(CubikContext context)
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