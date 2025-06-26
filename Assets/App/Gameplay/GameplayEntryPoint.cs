using UnityEngine;
using Zenject;

namespace Virsign
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [Inject] private ForkLift _forkLift;
        [Inject] private ForkLiftKeyboardInputAdapter _inputAdapter;

        private void Start()
        {
            _forkLift.Initialize();

            _inputAdapter.SetForkLift(_forkLift);
            _inputAdapter.DeActivate();
        }
    }
}