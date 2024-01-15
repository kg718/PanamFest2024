using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
  // Specify the name of the scene you want to open
    public string MainLevel;

    void Start()
    {
        // Get the button component on this GameObject
        Button NewGame = GetComponent<Button>();

        // Check if the button reference is assigned
        if (NewGame != null)
        {
            // Add a listener to the button that calls the OpenScene method when clicked
            NewGame.onClick.AddListener(OpenScene);
        }
        else
        {
            Debug.LogError("Button component not found!");
        }
    }

    // Method to open the specified scene
    void OpenScene()
    {
        // Check if the sceneToOpen is not empty
        if (!string.IsNullOrEmpty(MainLevel))
        {
            // Load the specified scene
            SceneManager.LoadScene(MainLevel);
        }
        else
        {
            Debug.LogError("Scene name not specified!");
        }
    }
}

