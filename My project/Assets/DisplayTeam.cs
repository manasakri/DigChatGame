using UnityEngine;
using UnityEngine.UI;

public class DisplayTeam : MonoBehaviour
{   public AvatarData avatarData; // Reference to the AvatarData script
    public Image avatarImage;

    void Start()
    {
        // Load avatar data when the scene starts
        AvatarData.Instance.LoadAvatarData();
        
        // Set the avatar image using the loaded data
        SetAvatarImage();
    }

    void SetAvatarImage()
    {
        // Retrieve the avatar data from AvatarData
        Sprite avatarSprite = AvatarData.Instance.currentSkin; // Assuming skin is the main part of the avatar

        // Update the image component with the retrieved sprite
        avatarImage.sprite = avatarSprite;
    }
}