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

        private ForkLiftInput _input;

        public void Initialize()
        {
            mainRigidbody.centerOfMass = centerOfMass.localPosition;

            _input = new();
            _input.Gas.OnValueChanged += OnGasChanged;
            _input.Steering.OnValueChanged += OnSteeringChanged;
            _input.Brake.OnValueChanged += OnBrakeChanged;

            engine.Initialize();
            fuelTank.Initialize();
            transmission.Initialize(engine);
            fork.Initialize();
        }

        private void OnGasChanged(float gasRatio)
        {
            engine.Input.GasRatio.SetValue(gasRatio);
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
            SetForkHeight();
        }

        private void SetGasStart()
        {
            var isIgnitionPressed = _input.IsIgnitionPressed.GetValue();
            engine.Input.Start.SetValue(isIgnitionPressed);
        }

        private void SetForkHeight()
        {
            var finalForkDelta = _input.ForkHeightDelta.GetValue();
            finalForkDelta *= forkMoveDelta;
            finalForkDelta *= Time.deltaTime;

            fork.AddDelta(finalForkDelta);
        }
    }
}