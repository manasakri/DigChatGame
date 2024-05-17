using UnityEngine;
using TMPro;

public class LoadingDots : MonoBehaviour
{
    public TextMeshProUGUI loadingText;
    public float dotInterval = 0.5f; // Interval between dot animations

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= dotInterval)
        {
            timer = 0f;
            UpdateDots();
        }
    }

    void UpdateDots()
    {
        // Toggle the visibility of dots
        loadingText.text = loadingText.text.Length < 3 ? loadingText.text + "." : "";
    }
}