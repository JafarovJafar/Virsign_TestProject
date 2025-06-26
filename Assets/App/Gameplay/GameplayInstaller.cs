using UnityEngine;
using Zenject;

namespace Virsign
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private ForkLift forkLift;
        [SerializeField] private ForkLiftKeyboardInputAdapter inputAdapter;
        [SerializeField] private LoadingScreen loadingScreen;

        public override void InstallBindings()
        {
            Container.BindInstance(forkLift);
            Container.BindInstance(inputAdapter);

            Container.BindInstance(loadingScreen);
        }
    }
}