using EasyButtons;
using UnityEngine;

namespace Virsign
{
    public class Cubik : MonoBehaviour
    {
        public Bounds Bounds
        {
            get
            {
                var finalBounds = new Bounds(Vector3.zero, Vector3.zero);

                foreach (var collider in colliders)
                {
                    finalBounds.Encapsulate(collider.bounds);
                }

                return finalBounds;
            }
        }

        [SerializeField] private Collider[] colliders;

        [Button]
        private void GetColliders()
        {
            colliders = GetComponentsInChildren<Collider>();
        }
    }
}