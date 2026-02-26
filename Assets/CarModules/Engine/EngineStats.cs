using UnityEngine;

namespace Virsign
{
    [CreateAssetMenu(menuName = "Virsign/EngineStats")]
    internal class EngineStats : ScriptableObject
    {
        public float TimeForStart => timeForStart;
        public float MaxRpm => maxRpm;
        public float MinRpm => minRpm;
        public float Acceleration => acceleration;
        public float Deceleration => deceleration;

        [SerializeField] private float timeForStart = 2f;
        [SerializeField] private float maxRpm = 1000f;
        [SerializeField] private float minRpm = -250f;
        [SerializeField] private float acceleration = 250f;
        [SerializeField] private float deceleration = 250f;
    }
}