using UnityEngine;

namespace Virsign
{
    // в дальнейшем данный класс можно доработать до чего-то по типу КПП
    public class EngineAdapter : MonoBehaviour
    {
        [SerializeField] private float gasMultiplier = 1000f;

        private Engine _engine;
        private WheelCollider[] _wheels;
        private float _gas;

        public void Initialize(Engine engine, params WheelCollider[] wheels)
        {
            _engine = engine;
            _wheels = wheels;
        }

        public void SetGas(float gas)
        {
            _gas = Mathf.Clamp(gas, 0f, 1f);
        }

        private void Update()
        {
            if (_engine.IsRunning == false)
                return;

            foreach (var wheel in _wheels)
            {
                wheel.motorTorque = _gas * gasMultiplier;
            }
        }
    }
}