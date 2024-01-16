using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResumeGame : MonoBehaviour
{
  public GameObject pauseMenu; // Assign the Pause Menu panel in the Unity Editor

    private void Start()
    {
        // Ensure the button is assigned and add a click listener
        Button resumeButton = GetComponent<Button>();
        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(Resume);
        }
    }

    void Resume()
    {
        Time.timeScale = 1f; // Resume the game

        // Set the PauseMenu panel inactive
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }

        // Hide the cursor
        Cursor.visible = false;
    }
}


