using UnityEngine;

namespace Virsign
{
    public class SteeringSystem : MonoBehaviour
    {
        [SerializeField] private WheelCollider[] wheels;
        [SerializeField] private float steeringAngle = 25f;

        public void SetSteering(float value)
        {
            value *= steeringAngle;
            value *= -1f;

            foreach (var wheel in wheels)
            {
                wheel.steerAngle = value;
            }
        }
    }
}