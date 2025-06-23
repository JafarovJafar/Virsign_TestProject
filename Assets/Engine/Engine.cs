using UnityEngine;

namespace Virsign
{
    public class Engine : MonoBehaviour
    {
        public EngineInput Input => _input;

        private EngineInput _input;

        public void Initialize()
        {
            _input = new EngineInput();

            _input.IsRunning.OnValueChanged += OnEngineIsRunningChanged;
            _input.GasRatio.OnValueChanged += OnGasChanged;
        }

        private void OnDestroy()
        {
            if (_input == null)
                return;

            _input.IsRunning.OnValueChanged -= OnEngineIsRunningChanged;
            _input.GasRatio.OnValueChanged -= OnGasChanged;
        }

        private void OnEngineIsRunningChanged(bool newValue)
        {
        }

        private void OnGasChanged(float newValue)
        {
        }
    }
}