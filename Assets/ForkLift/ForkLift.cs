using UnityEngine;

namespace Virsign
{
    public class ForkLift : MonoBehaviour
    {
        public ForkLiftInput Input => _input;

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

        [SerializeField] private float gas;
        [SerializeField] private float reverse;

        public void Initialize()
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

            gas = _input.Gas.Value;
            reverse = _input.Reverse.Value;
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