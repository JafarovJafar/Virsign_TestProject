using Shafir.EventBus;
using UnityEngine;
using Zenject;

namespace Virsign
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoader sceneLoader;

        public override void InstallBindings()
        {
            Container.BindInstance(sceneLoader);
            Container.BindInterfacesAndSelfTo<ShafirEventBus>().AsSingle();
        }
    }
}