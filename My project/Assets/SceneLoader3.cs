using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections; 

public class SceneLoader3 : MonoBehaviour
{
    public float fadeInDuration = 2f; // Duration of fade-in effect in seconds
    public CanvasGroup canvasGroup;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        // Set the initial alpha of the CanvasGroup to fully transparent
        canvasGroup.alpha = 0f;

        // Gradually fade in the CanvasGroup
        float timer = 0f;
        while (timer < fadeInDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeInDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Ensure the CanvasGroup is fully opaque
        canvasGroup.alpha = 1f;
    }
}