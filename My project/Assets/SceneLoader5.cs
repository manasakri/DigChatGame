using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController5 : MonoBehaviour
{
    void Start()
    {
        // Invoke the LoadNextScene method after 5 seconds
        Invoke("LoadNextScene", 4f);
    }

    void LoadNextScene()
    {
        // Load the scene with index 6
        SceneManager.LoadScene(8);
    }
}