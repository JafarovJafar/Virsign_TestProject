using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Virsign
{
    public class SceneLoader : MonoBehaviour
    {
        private bool _isBusy;
        private Coroutine _currentCoroutine;

        public void LoadSceneAdditive(int sceneIdx)
        {
            SceneManager.LoadScene(sceneIdx, LoadSceneMode.Additive);
        }

        public void LoadSceneAdditive(int sceneIdx, Action<float> progress = null, Action finished = null)
        {
            if (_isBusy == true)
            {
                StopCoroutine(_currentCoroutine);
            }

            var routine = LoadSceneCoroutine(sceneIdx, progress, finished);
            _currentCoroutine = StartCoroutine(routine);
        }

        public void UnLoadScene(int sceneIdx, Action<float> progress = null, Action finished = null)
        {
            if (_isBusy == true)
            {
                StopCoroutine(_currentCoroutine);
            }

            var routine = UnLoadSceneCoroutine(sceneIdx, progress, finished);
            _currentCoroutine = StartCoroutine(routine);
        }

        private IEnumerator LoadSceneCoroutine
        (
            int sceneIdx,
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

        private IEnumerator UnLoadSceneCoroutine
        (
            int sceneIdx,
            Action<float> progress,
            Action finished = null
        )
        {
            var operation = SceneManager.UnloadSceneAsync(sceneIdx);

            while (operation.isDone == false)
            {
                progress?.Invoke(operation.progress);
                yield return null;
            }

            finished?.Invoke();
        }
    }
}