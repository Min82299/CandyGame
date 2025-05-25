using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UILoading : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private float fillDuration = 2.0f;
    [SerializeField] private float delayAfterFill = 0.2f;
    
    private void Start()
    {
        progressBar.value = 0f;
        LoadScene();
    }
    
    private void OnDestroy()
    {
       
    }
    
    private IEnumerator UpdateProgressBar(float targetProgress)
    {
        float elapsed = 0f;
        float startValue = progressBar.value;
        
        while (elapsed < fillDuration)
        {
            elapsed += Time.deltaTime;
            progressBar.value = Mathf.Lerp(startValue, targetProgress, elapsed / fillDuration);
            yield return null;
        }
        
        // Ensure final value is exactly what we want
        progressBar.value = targetProgress;
    }
    
    private void LoadScene()
    {
        StartCoroutine(LoadSceneWithDelay());
    }
    
    private IEnumerator LoadSceneWithDelay()
    {
        yield return StartCoroutine(UpdateProgressBar(1f));
        
        yield return new WaitForSeconds(delayAfterFill);
        
        // Load the scene
        Loader.Load(Loader.Scene.GamePlay);
    }
}
