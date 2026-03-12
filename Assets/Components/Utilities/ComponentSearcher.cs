using UnityEngine;

namespace Virsign.Utilities
{
    public static class ComponentSearcher
    {
        public static bool TryGetComponent<T>(GameObject gameObject, out T component) where T : Component
        {
            if (gameObject.TryGetComponent(out component) == true)
                return true;

            if (gameObject.TryGetComponent(out Retargeter retargeter) == true)
            {
                if (retargeter.Target.TryGetComponent(out component) == true)
                    return true;
            }

            return false;
        }
    }
}