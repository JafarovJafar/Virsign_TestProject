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
        [SerializeField] private Fork fork;
        [SerializeField] private float forkMoveDelta = 1f;
        [SerializeField] private WheelCollider blWheel;
        [SerializeField] private WheelCollider brWheel;
        [SerializeField] private WheelCollider flWheel;
        [SerializeField] private WheelCollider frWheel;
        [SerializeField] private float steeringAngle = 45f;
        [SerializeField] private EngineAdapter engineAdapter;

        private ForkLiftInput _input;

        public void Initialize()
        {
            mainRigidbody.centerOfMass = centerOfMass.localPosition;

            _input = new();

            engine.Initialize();
            fuelTank.Initialize();
            fork.Initialize();
            engineAdapter.Initialize(engine, blWheel, brWheel, flWheel, frWheel);
        }

        private void Update()
        {
            SetGasStart();
            SetGas();
            SetSteering();
            SetForkHeight();
        }

        private void SetGasStart()
        {
            var isIgnitionPressed = _input.IsIgnitionPressed.GetValue();
            engine.Input.Start.SetValue(isIgnitionPressed);
        }

        private void SetGas()
        {
            engineAdapter.SetGas(_input.Gas.GetValue());
        }

        private void SetSteering()
        {
            var steering = _input.Steering.GetValue();
            steering *= Mathf.Abs(steeringAngle);
            steering *= -1f;

            blWheel.steerAngle = steering;
            brWheel.steerAngle = steering;
        }

        private void SetForkHeight()
        {
            if (_input.ForkUp.GetValue() == true)
                fork.AddDelta(forkMoveDelta * Time.deltaTime);
            else if (_input.ForkDown.GetValue() == true)
                fork.AddDelta(-forkMoveDelta * Time.deltaTime);
        }
    }
}