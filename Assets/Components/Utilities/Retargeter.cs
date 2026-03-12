using UnityEngine;

namespace Virsign.Utilities
{
    public class Retargeter : MonoBehaviour
    {
        public GameObject Target => target;

        [SerializeField] private GameObject target;
    }
}