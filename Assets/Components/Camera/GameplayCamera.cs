using UnityEngine;

namespace Virsign
{
    public class GameplayCamera : MonoBehaviour
    {
        [SerializeField] private float lerpSpeed = 5f;

        private Transform _target;

        private void Awake()
        {
            if (_target == null)
                DeActivate();
        }

        public void Activate()
        {
            enabled = true;
        }

        public void DeActivate()
        {
            enabled = false;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            enabled = true;
        }

        private void Update()
        {
            // знаю что не совсем правильное использование параметра T, то в рамках ТЗ это не сильно критично,
            // поэтому оставил как есть. Можно в целом просто Cinemachine прикрутить
            var finalPos = Vector3.Lerp(transform.position, _target.position, lerpSpeed * Time.deltaTime);
            transform.position = finalPos;
        }
    }
}