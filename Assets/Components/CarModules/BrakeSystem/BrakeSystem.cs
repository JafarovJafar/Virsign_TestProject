using UnityEngine;

namespace Virsign
{
    public class BrakeSystem : MonoBehaviour
    {
        [SerializeField] private WheelCollider[] wheels;
        [SerializeField] private float brakeStrength = 10000f;

        public void SetStrength(float strength)
        {
            var finalStrength = strength * brakeStrength;

            foreach (var wheel in wheels)
            {
                wheel.brakeTorque = finalStrength;
            }
        }
    }
}