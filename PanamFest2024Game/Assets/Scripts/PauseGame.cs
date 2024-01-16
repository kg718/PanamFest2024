using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu; // Assign the Pause Menu panel in the Unity Editor

    private bool isPaused = false;

    void Update()
    {
        // Check for the 'ESC' key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle between paused and unpaused states
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                GamePaused();
            }
        }
    }

    void GamePaused()
    {
        Time.timeScale = 0f; // Pause the game
        isPaused = true;

        // Set the PauseMenu panel active
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }

        // Show the cursor
        Cursor.visible = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        isPaused = false;

        // Set the PauseMenu panel inactive
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }

        // Hide the cursor
        Cursor.visible = false;
    }
}

