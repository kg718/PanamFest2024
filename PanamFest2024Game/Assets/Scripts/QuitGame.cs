using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
  
    void Start()
    {
        // Get the button component on this GameObject
        Button quit = GetComponent<Button>();

        // Check if the button reference is assigned
        if (quit != null)
        {
            // Add a listener to the button that calls the QuitGame method when clicked
            quit.onClick.AddListener(Quit);
        }
        else
        {
            Debug.LogError("Button component not found!");
        }
    }

    // Method to quit the application
    void Quit()
    {
        // Quit the application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}


