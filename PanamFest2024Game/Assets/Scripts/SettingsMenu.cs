using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    void Start()
    {
        // Make sure both panels are initially in the desired state
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void ToggleSettingsPanel()
    {
        // Toggle the visibility of the panels
        mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }
}

