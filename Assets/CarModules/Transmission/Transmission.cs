using UnityEngine;

namespace Virsign
{
    public class Transmission : MonoBehaviour
    {
        [SerializeField] private WheelCollider[] wheels;
        [SerializeField] private float rpmMultiplier = 0.1f;

        private Engine _engine;

        public void Initialize(Engine engine)
        {
            _engine = engine;
            UpdateWheelsRpm(_engine.CurrentRpm.GetValue());
            _engine.CurrentRpm.OnValueChanged += UpdateWheelsRpm;
        }

        private void UpdateWheelsRpm(float engineRpm)
        {
            var finalMotorTorque = engineRpm * rpmMultiplier;

            foreach (var wheel in wheels)
            {
                wheel.motorTorque = finalMotorTorque;
            }
        }
    }
}