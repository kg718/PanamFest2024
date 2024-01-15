using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditssMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject creditsPanel;

    void Start()
    {
        // Make sure both panels are initially in the desired state
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void ToggleSettingsPanel()
    {
        // Toggle the visibility of the panels
        mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
        creditsPanel.SetActive(!creditsPanel.activeSelf);
    }
}

