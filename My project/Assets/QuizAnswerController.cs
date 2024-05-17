using UnityEngine;
using UnityEngine.UI;
using System.Collections; 
public class FadeOutImages : MonoBehaviour
{
    public float fadeDuration = 1f;
    public Image[] imagesToFade;

    private void Start()
    {
        // Start the fading process after 4 seconds
        Invoke("FadeOut", 4f);
    }

    private void FadeOut()
    {
        foreach (Image image in imagesToFade)
        {
            StartCoroutine(FadeOutImage(image));
        }
    }

    private IEnumerator FadeOutImage(Image image)
    {
        float elapsedTime = 0f;
        Color startColor = image.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            image.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            yield return null;
        }

        // Deactivate the image after fading out
        image.gameObject.SetActive(false);
    }
}