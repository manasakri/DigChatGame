using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust rotation speed as needed
    public float waitTime = 5f; // Time to wait between rotations

    private bool isLoading = true; // Control loading state
    private float currentRotationAngle = 0f; // Store current rotation angle

    void Start()
    {
        StartCoroutine(LoadingAnimation());
    }

    IEnumerator LoadingAnimation()
    {
        while (isLoading)
        {
            // Rotate the image until one rotation circle is complete
            float targetAngle = currentRotationAngle + 360f;
            float elapsedTime = 0f;
            while (currentRotationAngle < targetAngle)
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                currentRotationAngle += rotationSpeed * Time.deltaTime;
                yield return null;
            }

            // Wait for a few seconds
            yield return new WaitForSeconds(waitTime);

            // Reset rotation angle for the next cycle
            currentRotationAngle %= 360f;
        }
    }
}