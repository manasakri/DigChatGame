using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarData : MonoBehaviour
{
    // Singleton instance
    public static AvatarData Instance;
    public Sprite currentSkin;
    public Sprite currentEyes;
    public Sprite currentEyebrows;
    // Add other avatar customization variables as needed


    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        //  across scenes
        DontDestroyOnLoad(gameObject);
    }

    // Method to save avatar data
    public void SaveAvatarData()
    {
        // Save avatarData using PlayerPrefs or another method
        PlayerPrefs.SetString("AvatarData", JsonUtility.ToJson(this));
    }

    // Method to load avatar data
    public void LoadAvatarData()
    {
        print("inside LoadAvatar");
        // Load saved avatar data from PlayerPrefs or another method
        string avatarDataJson = PlayerPrefs.GetString("AvatarData");
     
        print(avatarDataJson);
      
        if (!string.IsNullOrEmpty(avatarDataJson))
        {
            print("AvatarData is not Null");
            // Deserialize the JSON data into this object
            JsonUtility.FromJsonOverwrite(avatarDataJson, this);
            
        }
    }
}