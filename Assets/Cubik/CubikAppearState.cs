using DG.Tweening;
using Shafir.FSM;
using UnityEngine;

namespace Virsign
{
    public class CubikAppearState : IState
    {
        private CubikContext _context;

        private Sequence _sequence;
        private float _duration = 5f;
        private float _heightOffset = 100f; // оффсет к целевой позиции, чтобы кубик появился как бы извне камеры

        public CubikAppearState(CubikContext context)
        {
            _context = context;
        }

        public void Enter()
        {
            _context.Rigidbody.isKinematic = true;
            foreach (var collider in _context.Colliders)
            {
                collider.enabled = false;
            }

            var duration = 5f;

            var startPos = _context.GoalPos;
            startPos.y += _heightOffset;
            _context.Transform.position = startPos;
            _context.Transform.rotation = Quaternion.identity;

            _sequence = DOTween.Sequence();
            _sequence.Append(_context.Transform.DOMove(_context.GoalPos, _duration));
            var goalRot = new Vector3(0f, 360f, 0f);
            _sequence.Insert(0f, _context.Transform.DORotate(goalRot, _duration, RotateMode.FastBeyond360));
        }

        public void Exit()
        {

        }
    }
}