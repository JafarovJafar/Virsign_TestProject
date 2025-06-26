using UnityEngine;
using Zenject;

namespace Virsign
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoader sceneLoader;

        public override void InstallBindings()
        {
            Debug.LogError(111);
            Container.BindInstance(sceneLoader);
        }
    }
}