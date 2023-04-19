using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ALoading : MonoBehaviour
{
    private Coroutine coroutine;
    private static readonly object delayLoading = new WaitForSeconds(0.5f);

    private void Awake()
    {
        this.SetTimeScale(1);
        Loading();
        
    }

    public void Loading()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(RunLoading());
    }

    IEnumerator RunLoading()
    {
        yield return delayLoading;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Home");
    }
}
