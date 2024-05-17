using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownController : MonoBehaviour
{
    public TMP_Text[] countdownTexts; // Array to store the TMP_Text elements for countdown
    public float fadeDuration = 1.0f; // Duration of fade-in animation for each number

    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        // Iterate through each TMP_Text element for countdown
        foreach (TMP_Text countdownText in countdownTexts)
        {
            // Activate the current TMP_Text element
            countdownText.gameObject.SetActive(true);

            // Fade in the current TMP_Text element
            StartCoroutine(FadeIn(countdownText));

            // Wait for the fade-in animation to complete
            yield return new WaitForSeconds(fadeDuration);
        }
    }

    IEnumerator FadeIn(TMP_Text textElement)
    {
        // Get the color of the text
        Color originalColor = textElement.color;
        
        // Gradually fade in the TMP_Text element
        float timer = 0f;
        while (timer < fadeDuration)
        {
            // Calculate the current alpha value
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            
            // Set the alpha value of the text color
            textElement.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            // Increase the timer
            timer += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the TMP_Text element is fully visible
        textElement.color = originalColor;
    }
}