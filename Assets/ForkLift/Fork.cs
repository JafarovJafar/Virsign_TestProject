using UnityEngine;

namespace Virsign
{
    internal class Fork : MonoBehaviour
    {
        public float CurrentPosT => _currentPosT;

        [SerializeField] private Transform transformForMoving;

        [SerializeField] private bool drawGizmos;

        [SerializeField] private float minPos;
        [SerializeField] private float maxPos;

        private float _currentPos;
        private float _currentPosT;

        public void Initialize()
        {
            _currentPos = minPos;
            _currentPosT = 0f;
            UpdateViewPos();
        }

        public void AddDelta(float delta)
        {
            _currentPos = Mathf.Clamp(_currentPos + delta, minPos, maxPos);
            _currentPosT = (_currentPos - minPos) / (maxPos - minPos);
            UpdateViewPos();
        }

        private void UpdateViewPos()
        {
            transformForMoving.localPosition = new Vector3(0f, _currentPos, 0f);
        }

        private void OnDrawGizmos()
        {
            if (drawGizmos == false)
                return;

            if (transformForMoving == null)
                return;

            if (transformForMoving.parent == null)
                return;

            var gizmoMinPos = transformForMoving.position;
            gizmoMinPos.y = transformForMoving.parent.position.y;
            gizmoMinPos.y += minPos;
            var gizmoMaxPos = transformForMoving.position;
            gizmoMaxPos.y = transformForMoving.parent.position.y;
            gizmoMaxPos.y += maxPos;

            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(gizmoMinPos, 0.1f);
            Gizmos.DrawSphere(gizmoMaxPos, 0.1f);
        }
    }
}