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
            _context.Rigidbody.isKinematic = false;
            foreach (var collider in _context.Colliders)
            {
                collider.enabled = true;
            }
        }

        public void Exit()
        {

        }
    }
}