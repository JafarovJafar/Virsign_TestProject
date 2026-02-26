using Shafir.MonoPool;
using UnityEngine;

namespace Virsign
{
    public class ForkLift : MonoBehaviour, IPoolable
    {
        public ForkLiftInput Input => _input;
        public bool IsActive => gameObject.activeSelf;

        [SerializeField] private Rigidbody mainRigidbody;
        [SerializeField] private Transform centerOfMass;

        [SerializeField] private Engine engine;
        [SerializeField] private FuelTank fuelTank;
        [SerializeField] private Transmission transmission;
        [SerializeField] private BrakeSystem brakeSystem;
        [SerializeField] private SteeringSystem steeringSystem;
        [SerializeField] private Fork fork;
        [SerializeField] private float forkMoveDelta = 1f;
        [SerializeField] private ExhaustSystem exhaustSystem;

        private ForkLiftInput _input;

        private bool _isInitialized;

        private void Awake()
        {
            if (_isInitialized == true)
            {
                return;
            }

            Initialize();
        }

        public void Activate()
        {
            if (_isInitialized == false)
            {
                Initialize();
            }

            _input.Clear();
            gameObject.SetActive(true);
            // тут например еще можно сделать переходы в дефолтное состояние
            // сейчас просто тут нет машины состояний
        }

        public void DeActivate()
        {
            gameObject.SetActive(false);
        }

        private void Initialize()
        {
            mainRigidbody.centerOfMass = centerOfMass.localPosition;

            _input = new();
            _input.Steering.OnValueChanged += OnSteeringChanged;
            _input.Brake.OnValueChanged += OnBrakeChanged;

            engine.Initialize();
            fuelTank.Initialize();
            transmission.Initialize(engine);
            fork.Initialize();
            exhaustSystem.Initialize(engine);

            _isInitialized = true;
        }

        private void OnSteeringChanged(float steering)
        {
            steeringSystem.SetSteering(steering);
        }

        private void OnBrakeChanged(float brakesStrength)
        {
            brakeSystem.SetStrength(brakesStrength);
        }

        private void Update()
        {
            SetGasStart();
            SetGas();
            SetForkHeight();
        }

        private void SetGasStart()
        {
            var isIgnitionPressed = _input.IsIgnitionPressed.Value;
            engine.Input.Start.SetValue(isIgnitionPressed);
        }

        private void SetGas()
        {
            var finalGasRatio = -_input.Reverse.Value;
            finalGasRatio += _input.Gas.Value;
            engine.Input.GasRatio.SetValue(finalGasRatio);
        }

        private void SetForkHeight()
        {
            var finalForkDelta = _input.ForkHeightDelta.Value;
            finalForkDelta *= forkMoveDelta;
            finalForkDelta *= Time.deltaTime;

            fork.AddDelta(finalForkDelta);
        }
    }
}