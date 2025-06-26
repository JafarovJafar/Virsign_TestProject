using UnityEngine;
using Zenject;

namespace Virsign
{
    public class BootstrapEntryPoint : MonoBehaviour
    {
        // конкретно по данной задаче не требуется этот класс,
        // но вообще в случае какой-либо минимальной доработки
        // данный класс потребуется

        [Inject] private SceneLoader _sceneLoader;

        private void Start()
        {
            var nextSceneIdx = 1;

            _sceneLoader.LoadSceneAdditive(nextSceneIdx);
        }
    }
}