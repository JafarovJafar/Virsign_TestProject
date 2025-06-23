using UnityEngine;
using Virsign;

public class FadeTestScript : MonoBehaviour
{
    [SerializeField] private LoadingScreen loadingScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            loadingScreen.Show(OnShowFinished);
        else if (Input.GetKeyDown(KeyCode.H))
            loadingScreen.Hide(OnHideFinished);
    }

    private void OnShowFinished()
    {
        Debug.LogError("Shown");
    }

    private void OnHideFinished()
    {
        Debug.LogError("Hidden");
    }
}