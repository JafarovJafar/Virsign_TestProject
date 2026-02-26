using UnityEngine;

namespace Virsign
{
    public class WheelSynchronizer : MonoBehaviour
    {
        [SerializeField] private WheelCollider wheelCollider;

        private void Update()
        {
            /*var steerAngle = wheelCollider.steerAngle;
            var xDiff = wheelCollider.rotationSpeed;

            var finalRot = transform.localEulerAngles;
            finalRot.x += xDiff * Time.deltaTime;
            finalRot.y = steerAngle;

            transform.localEulerAngles = finalRot;*/
            
            wheelCollider.GetWorldPose(out var worldPos, out var worldRot);
            transform.SetPositionAndRotation(worldPos, worldRot);
        }
    }
}