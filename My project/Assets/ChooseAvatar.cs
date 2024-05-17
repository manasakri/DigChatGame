using UnityEngine;
using UnityEngine.UI;
public class ChooseAvatar : MonoBehaviour
{
    public Image avatarPortrait;
    public Sprite Skin1; // Default skin image
    public Sprite Skin2; // Default skin image
    public Sprite Skin3; // Default skin image

    public Sprite Eyes1; // Default eyes image
    public Sprite Eyes2; // Default eyes image
    public Sprite Eyes3; // Default eyes image

    public Sprite Eyebrows1; // Default eyebrows image
    public Sprite Eyebrows2; // Default eyebrows image
    public Sprite Eyebrows3; // Default eyebrows image

    public Sprite Hairs1; // Default hairs image
    public Sprite Hairs2; // Default hairs image
    public Sprite Hairs3; // Default hairs image

    public Sprite Mouths1; // Default mouths image
    public Sprite Mouths2; // Default mouths image
    public Sprite Mouths3; // Default mouths image

    public Sprite Moustaches1; // Default moustaches image
    public Sprite Moustaches2; // Default moustaches image
    public Sprite Moustaches3; // Default moustaches image

    public Sprite Outfits1; // Default outfits image
    public Sprite Outfits2; // Default outfits image
    public Sprite Outfits3; // Default outfits image

    private Sprite currentSkin;
    private Sprite currentEyes;
    private Sprite currentEyebrows;
    private Sprite currentHairs;
    private Sprite currentMouths;
    private Sprite currentMoustaches;
    private Sprite currentOutfits;
    public Button deleteButton;

    private Sprite previousEyes; // To keep track of previously selected eyes
    private string currentHairStyle; 
    private Color currentHairColor; 

    private void Start()
    {
        // Set default skin and eyes
        currentSkin = null;
        currentEyes = null; // No default eyes initially
        currentEyebrows = null;
        currentHairs = null;
        currentMouths = null;
        currentMoustaches = null;
        currentOutfits = null;
        
        AvatarData.Instance.LoadAvatarData();
        UpdateAvatar();
      

    }

    public void OnSkinButtonClicked(Sprite skinSprite)
    {
        currentSkin = skinSprite;
        avatarPortrait.sprite = currentSkin;
        UpdateAvatar();
    }

    public void OnEyesButtonClicked(Sprite eyesSprite)
    {
        previousEyes = currentEyes; // Save the previous eyes sprite
        currentEyes = eyesSprite;
        UpdateAvatar();
    }

    public void OnEyebrowsButtonClicked(Sprite eyebrowsSprite)
    {
        currentEyebrows = eyebrowsSprite;
        UpdateAvatar();
    }

    public void OnHairsButtonClicked(Sprite hairsSprite)
    {
        currentHairs = hairsSprite;
        currentHairStyle = hairsSprite.name; // Assuming the name of the sprite corresponds to the hair style
        UpdateAvatar();
    }

    public void OnMouthsButtonClicked(Sprite mouthsSprite)
    {
        currentMouths = mouthsSprite;
        UpdateAvatar();
    }

    public void OnMoustachesButtonClicked(Sprite moustachesSprite)
    {
        currentMoustaches = moustachesSprite;
        UpdateAvatar();
    }

    public void OnOutfitsButtonClicked(Sprite outfitsSprite)
    {
        currentOutfits = outfitsSprite;
        UpdateAvatar();
    }

    private void UpdateAvatar()
    {
        // Set default image (assuming a base skin tone is needed)

        // Combine eyes with the base sprite
        if (currentEyes != null)
        {
            // Combine the new eyes with the base sprite
            avatarPortrait.sprite = CombineSprites(avatarPortrait.sprite, currentEyes);
        }

        // Combine eyebrows with the base sprite
        if (currentEyebrows != null)
        {
            avatarPortrait.sprite = CombineSprites(avatarPortrait.sprite, currentEyebrows);
        }

        // Combine hairs with the base sprite
        if (currentHairs != null)
        {
            avatarPortrait.sprite = CombineSprites(avatarPortrait.sprite, currentHairs);
        }

        // Combine mouths with the base sprite
        if (currentMouths != null)
        {
            avatarPortrait.sprite = CombineSprites(avatarPortrait.sprite, currentMouths);
        }

        // Combine moustaches with the base sprite
        if (currentMoustaches != null)
        {
            avatarPortrait.sprite = CombineSprites(avatarPortrait.sprite, currentMoustaches);
        }

        // Combine outfits with the base sprite
        if (currentOutfits != null)
        {
            avatarPortrait.sprite = CombineSprites(avatarPortrait.sprite, currentOutfits);
        }
    }

    // Combine two sprites into one
   public static Sprite CombineSprites(Sprite baseSprite, Sprite overlaySprite)
    {
        // Check if either base or overlay sprite is null
        if (baseSprite == null && overlaySprite == null)
        {
            return null; // Return null if both sprites are null
        }
        else if (baseSprite == null)
        {
            return overlaySprite; // Return overlay sprite if base sprite is null
        }
        else if (overlaySprite == null)
        {
            return baseSprite; // Return base sprite if overlay sprite is null
        }

        // Get the textures of the base and overlay sprites
        Texture2D baseTexture = baseSprite.texture;
        Texture2D overlayTexture = overlaySprite.texture;

        // Get the width and height of the textures
        int width = baseTexture.width;
        int height = baseTexture.height;

        // Create a new texture for the combined sprite
        Texture2D combinedTexture = new Texture2D(width, height);

        // Loop through each pixel of the textures
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Get the color of the pixels from the base and overlay textures
                Color baseColor = baseTexture.GetPixel(x, y);
                Color overlayColor = overlayTexture.GetPixel(x, y);

                // Combine the colors using alpha blending
                Color finalColor = Color.Lerp(baseColor, overlayColor, overlayColor.a);

                // Set the color of the pixel in the combined texture
                combinedTexture.SetPixel(x, y, finalColor);
            }
        }

        // Apply changes to the combined texture
        combinedTexture.Apply();

        // Create a sprite from the combined texture
        Sprite combinedSprite = Sprite.Create(combinedTexture, new Rect(0, 0, width, height), Vector2.one * 0.5f);

        return combinedSprite;
    }

   void SaveAvatarData()
   {
       // Save avatar data using AvatarDataManager
       AvatarData.Instance.SaveAvatarData();
   }

}
