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
        [SerializeField] private float torqueValue = 100f;

        [SerializeField] private float steeringAngle = 45f;

        private ForkLiftInput _input;

        public void Initialize()
        {
            mainRigidbody.centerOfMass = centerOfMass.localPosition;

            _input = new();

            engine.Initialize();
            fuelTank.Initialize();
            fork.Initialize();
        }

        private void Update()
        {
            SetGas();
            SetSteering();
            SetForkHeight();
        }

        private void SetGas()
        {
            var gas = _input.Gas.GetValue();
            gas *= torqueValue;
            flWheel.motorTorque = gas;
            frWheel.motorTorque = gas;
        }

        private void SetSteering()
        {
            var steering = _input.Steering.GetValue();
            steering *= steeringAngle;

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