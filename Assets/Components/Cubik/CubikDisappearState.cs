using System;
using DG.Tweening;
using Shafir.FSM;
using UnityEngine;

namespace Virsign
{
    public class CubikDisappearState : IState
    {
        public event Action Finished;

        private CubikContext _context;

        // оффсет к целевой позиции, чтобы кубик появился как бы извне камеры
        // (это точно должно настраиваться, но в рамках ТЗ норм)
        private float _heightOffset = 50f;

        // (это точно должно настраиваться, но в рамках ТЗ норм)
        private const float Duration = 5f;

        public CubikDisappearState(CubikContext context)
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

            var goalPos = _context.Transform.position;
            goalPos.y += _heightOffset;

            var sequence = DOTween.Sequence();
            sequence.Append(_context.Transform.DOMove(goalPos, Duration));
            var goalRot = new Vector3(0f, 360f, 0f);
            sequence.Insert(0f, _context.Transform.DORotate(goalRot, Duration, RotateMode.FastBeyond360));
            sequence.OnComplete(() => Finished?.Invoke());
        }

        public void Exit()
        {

        }
    }
}