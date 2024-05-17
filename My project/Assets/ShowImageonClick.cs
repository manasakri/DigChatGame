using UnityEngine;
using UnityEngine.UI;

public class ButtonImageController : MonoBehaviour
{
    public GameObject imageToShow;

    // Start is called before the first frame update
    void Start()
    {
        // Hide the image initially
        imageToShow.SetActive(false);
    }

    // Method to be called when the button is clicked
    public void ToggleImage()
    {
        // Toggle the visibility of the image
        imageToShow.SetActive(!imageToShow.activeSelf);
    }
}