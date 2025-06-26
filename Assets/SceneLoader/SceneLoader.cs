using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Virsign
{
    public class SceneLoader : MonoBehaviour
    {
        private bool _isAlreadyLoadingScene;
        private Coroutine _loadCoroutine;

        public void LoadScene(int sceneIdx)
        {
            SceneManager.LoadScene(sceneIdx);
        }

        public void LoadSceneAdditive(int sceneIdx)
        {
            SceneManager.LoadScene(sceneIdx, LoadSceneMode.Additive);
        }

        public void LoadSceneAdditive(int sceneIdx, Action<float> progress, Action finished)
        {
            if (_isAlreadyLoadingScene == true)
            {
                StopCoroutine(_loadCoroutine);
            }

            var routine = LoadSceneCoroutine(sceneIdx, LoadSceneMode.Additive, progress, finished);
            _loadCoroutine = StartCoroutine(routine);
        }

        private IEnumerator LoadSceneCoroutine
        (
            int sceneIdx,
            LoadSceneMode loadSceneMode,
            Action<float> progress,
            Action finished = null
        )
        {
            var operation = SceneManager.LoadSceneAsync(sceneIdx, LoadSceneMode.Additive);

            while (operation.isDone == false)
            {
                progress?.Invoke(operation.progress);
                yield return null;
            }

            finished?.Invoke();
        }
    }
}