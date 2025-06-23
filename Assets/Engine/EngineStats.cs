using UnityEngine;

namespace Virsign
{
    [CreateAssetMenu(menuName = "Virsign/EngineStats")]
    internal class EngineStats : ScriptableObject
    {
        public float TimeForStart => timeForStart;

        [SerializeField] private float timeForStart = 2f;
    }
}