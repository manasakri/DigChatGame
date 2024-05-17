using UnityEngine;
using UnityEngine.UI;

public class EnterPin : MonoBehaviour
{
    public Image[] keyInputFields; // Array of KeyInputField images
    public Sprite clickedSprite; // The sprite to display on the KeyInputField

    public Button button1; // Reference to Button 1
    public Button button2; // Reference to Button 2
    public Button button3; // Reference to Button 3
    public Button button4; // Reference to Button 4
    public Button button5; // Reference to Button 5
    public Button button6; // Reference to Button 6
    public Button button7; // Reference to Button 7
    public Button button8; // Reference to Button 8
    public Button button9; // Reference to Button 9
    public Button deleteButton;
    
    private bool[] _keyInputFieldsAvailable; // Array to track availability of KeyInputFields
    private int _lastUsedIndex; // Index of the last used KeyInputField

    void Start()
    {
        // Initialize the availability array
        _keyInputFieldsAvailable = new bool[keyInputFields.Length];
        for (int i = 0; i < _keyInputFieldsAvailable.Length; i++)
        {
            _keyInputFieldsAvailable[i] = true;
        }

        // Initialize the last used index
        _lastUsedIndex = 0;
        
        deleteButton.onClick.AddListener(OnDeleteButtonClick);

    }

    // Method to handle button clicks for Button 1
    public void OnButton1Click()
    {
        OnButtonClick(button1); // Call the common button click handler
    }

    // Method to handle button clicks for Button 2
    public void OnButton2Click()
    {
        OnButtonClick(button2); // Call the common button click handler
    }

    // Method to handle button clicks for Button 3
    public void OnButton3Click()
    {
        OnButtonClick(button3); // Call the common button click handler
    }
    
    public void OnButton4Click()
    {
        OnButtonClick(button4); // Call the common button click handler
    }
    
    public void OnButton5Click()
    {
        OnButtonClick(button5); // Call the common button click handler
    }

    public void OnButton6Click()
    {
        OnButtonClick(button6); // Call the common button click handler
    }
    
    public void OnButton7Click()
    {
        OnButtonClick(button7); // Call the common button click handler
    }
    
    public void OnButton8Click()
    {
        OnButtonClick(button8); // Call the common button click handler
    }
    
    public void OnButton9Click()
    {
        OnButtonClick(button9); // Call the common button click handler
    }
    private void OnButtonClick(Button button)
    {
        // Find the next available KeyInputField
        int nextAvailableIndex = FindNextAvailableIndex();
        if (nextAvailableIndex != -1) {
            // Update the sprite of the current KeyInputField with button's sprite
            keyInputFields[nextAvailableIndex].sprite = button.GetComponent<Image>().sprite;
            
            // Mark the KeyInputField as unavailable
            _keyInputFieldsAvailable[nextAvailableIndex] = false;

            // Update the last used index to the next available index
            _lastUsedIndex = nextAvailableIndex;

            // Log the last used index for debugging
            Debug.Log("Last used index: " + _lastUsedIndex);
        }
    }
    private void OnDeleteButtonClick()
    {
        // Find the index of the last used KeyInputField
        int lastUsedIndex = FindLastUsedIndex();
        if (lastUsedIndex != -1) {
            // Reset the sprite of the last used KeyInputField
            keyInputFields[lastUsedIndex].sprite = clickedSprite;
            
            // Mark the KeyInputField as available
            _keyInputFieldsAvailable[lastUsedIndex] = true;

            // Update the last used index to the previous index
            _lastUsedIndex = Mathf.Max(0, lastUsedIndex - 1); // Ensure _lastUsedIndex is within bounds

            // Log the last used index for debugging
            Debug.Log("Last used index after delete: " + _lastUsedIndex);
        }
    }

    private int FindNextAvailableIndex()
    {
        for (int i = _lastUsedIndex; i < _keyInputFieldsAvailable.Length; i++) {
            if (_keyInputFieldsAvailable[i])
            {
                Debug.Log("Next available index: " + i);
                return i;
            }
        }
        Debug.Log("No available KeyInputField found");
        return -1; // No available KeyInputField found
    }
    
    private int FindLastUsedIndex()
    {
        for (int i = _keyInputFieldsAvailable.Length - 1; i >= 0; i--) {
            if (!_keyInputFieldsAvailable[i])
            {
                return i;
            }
        }
        return -1; // No used KeyInputField found
    }
}

