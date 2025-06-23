using UnityEngine;

namespace Virsign
{
    public class ForkLift : MonoBehaviour
    {
        public ForkLiftInput Input => _input;

        [SerializeField] private Engine engine;
        [SerializeField] private FuelTank fuelTank;
        [SerializeField] private Fork fork;

        [SerializeField] private float forkMoveDelta = 1f;

        private ForkLiftInput _input;

        public void Initialize()
        {
            _input = new();

            engine.Initialize();
            fuelTank.Initialize();
            fork.Initialize();
        }

        private void Update()
        {
            if (_input.ForkUp.GetValue() == true)
                fork.AddDelta(forkMoveDelta * Time.deltaTime);
            else if (_input.ForkDown.GetValue() == true)
                fork.AddDelta(-forkMoveDelta * Time.deltaTime);
        }
    }
}