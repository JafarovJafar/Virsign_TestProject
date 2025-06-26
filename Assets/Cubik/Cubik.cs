using EasyButtons;
using Shafir.FSM;
using Shafir.MonoPool;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Virsign
{
    public class Cubik : MonoBehaviour, IPoolable
    {
        public bool IsActive => gameObject.activeInHierarchy;

        public Bounds Bounds
        {
            get
            {
                var finalBounds = new Bounds(Vector3.zero, Vector3.zero);

                foreach (var collider in colliders)
                {
                    finalBounds.Encapsulate(collider.bounds);
                }

                return finalBounds;
            }
        }

        [SerializeField] private Collider[] colliders;
        [SerializeField] private Rigidbody rigidbody;

        private CubikContext _context;
        private CubikAppearState _appearState;
        private CubikNormalState _normalState;
        private CubikDisappearState _disappearState;
        private SimpleStateMachine _stateMachine;

        private bool _isInitialized;

        public void Activate()
        {
            if (_isInitialized == false)
                Initialize();

            gameObject.SetActive(true);
        }

        public void DeActivate()
        {
            gameObject.SetActive(false);
        }

        private void Initialize()
        {
            _context = new()
            {
                Transform = transform,
                Colliders = colliders,
                Rigidbody = rigidbody,
            };

            _appearState = new(_context);
            _appearState.Finished += OnAppearStateFinished;
            _normalState = new(_context);
            _disappearState = new(_context);

            _stateMachine = new(Debug.LogError);

            _isInitialized = true;
        }

        public void AppearTo(Vector3 pos)
        {
            _context.GoalPos = pos;
            _stateMachine.ChangeState(_appearState);
        }

        private void OnAppearStateFinished()
        {
            _stateMachine.ChangeState(_normalState);
        }

#if UNITY_EDITOR
        [Button]
        private void GetColliders()
        {
            colliders = GetComponentsInChildren<Collider>();
            EditorUtility.SetDirty(this);
        }
#endif
    }
}