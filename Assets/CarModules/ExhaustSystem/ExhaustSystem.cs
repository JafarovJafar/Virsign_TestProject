using UnityEngine;

namespace Virsign
{
    public class ExhaustSystem : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particle;

        private Engine _engine;

        public void Initialize(Engine engine)
        {
            _engine = engine;
            _engine.IsRunning.OnValueChanged += OnEngineIsRunningChanged;
        }

        private void OnEngineIsRunningChanged(bool isEngineRunning)
        {
            if (isEngineRunning == true)
                particle.Play();
            else
                particle.Stop();
        }
    }
}