using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject currentPanel;

    private GameObject currentActivePanel;

    void Start()
    {
        // Initialize the current active panel to the main menu panel
        currentActivePanel = mainMenuPanel;

        // Make sure both panels are initially in the desired state
        mainMenuPanel.SetActive(true);
        currentPanel.SetActive(false);
    }

    public void ToggleSettingsPanel()
    {
        // Toggle the visibility of the current active panel
        currentActivePanel.SetActive(false);

        // Switch the current active panel to the other panel
        currentActivePanel = (currentActivePanel == mainMenuPanel) ? currentPanel : mainMenuPanel;

        // Toggle the visibility of the new current active panel
        currentActivePanel.SetActive(true);
    }
}
