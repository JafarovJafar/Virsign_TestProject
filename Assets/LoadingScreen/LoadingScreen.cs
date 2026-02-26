using System;
using System.Collections;
using UnityEngine;

namespace Virsign
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private float fadeDuration = 0.5f;
        [SerializeField] private CanvasGroup canvasGroup;

        private bool _isFading = false;

        public void Show(Action finished = null)
        {
            if (_isFading == true)
            {
                Debug.LogError("Предыдущий фейд не завершен!!!");
                return;
            }

            canvasGroup.blocksRaycasts = true;

            StartCoroutine(FadeCoroutine(0f, 1f, fadeDuration, () => finished?.Invoke()));
        }

        public void Hide(Action finished = null)
        {
            if (_isFading == true)
            {
                Debug.LogError("Предыдущий фейд не завершен!!!");
                return;
            }

            StartCoroutine(FadeCoroutine(1f, 0f, fadeDuration, () =>
            {
                canvasGroup.blocksRaycasts = false;
                finished?.Invoke();
            }));
        }

        private IEnumerator FadeCoroutine(float startAlpha, float endAlpha, float duration, Action finished)
        {
            _isFading = true;

            var t = 0f;
            var speed = 1f / duration;

            while (t < 1f)
            {
                t += Time.deltaTime * speed;
                var alpha = Mathf.Lerp(startAlpha, endAlpha, t);
                canvasGroup.alpha = alpha;

                yield return null;
            }

            _isFading = false;

            finished?.Invoke();
        }
    }
}