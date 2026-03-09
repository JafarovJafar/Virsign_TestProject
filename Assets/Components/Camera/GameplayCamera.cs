using UnityEngine;

namespace Virsign
{
    public class GameplayCamera : MonoBehaviour
    {
        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
            enabled = true;
        }

        private void Awake()
        {
            if (_target == null)
                enabled = false;
        }

        private void LateUpdate() =>
            transform.position = _target.position;
    }
}