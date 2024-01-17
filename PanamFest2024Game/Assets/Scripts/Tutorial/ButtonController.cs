using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject[] tutorialPanels;
    public int currentPanelIndex = 0;
    public Button NotebookSelect;

    // Reference to the UI button
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        // Find the Button component on the GameObject
        button = GetComponent<Button>();
        button.Select();
        // Check if the Button component is found
        if (button != null)
        {
            // Add an onClick listener to the button
            button.onClick.AddListener(OnButtonClicked);
        }
        else
        {
            Debug.LogError("Button component not found on the GameObject.");
        }

        // Set the initial panel states
        SetPanelStates();
        Time.timeScale = 0;
    }

    // Function to be called when the button is clicked
    public void OnButtonClicked()
    {
        // Toggle off the current panel
        tutorialPanels[currentPanelIndex].SetActive(false);

        // Increment the panel index
        currentPanelIndex++;

        // Check if the index is within the bounds of the array
        if (currentPanelIndex < tutorialPanels.Length)
        {
            // Toggle on the next panel
            tutorialPanels[currentPanelIndex].SetActive(true);

            // Check if the index is equal to 2 to stop the loop
            if (currentPanelIndex == 3)
            {
                tutorialPanels[currentPanelIndex].SetActive(false);
                // Hide the button
                SetButtonVisibility(false);

                button.enabled = false;
                Time.timeScale = 1;
            }
        }
        else
        {
            // If the index is out of bounds, reset to the beginning
            currentPanelIndex = 0;

            // Toggle on the first panel
            tutorialPanels[currentPanelIndex].SetActive(true);

            // Re-enable the button to restart the loop
            SetButtonVisibility(true);
        }
    }

    // Set the initial states of the panels
    void SetPanelStates()
    {
        for (int i = 0; i < tutorialPanels.Length; i++)
        {
            // Disable all panels except the first one
            if (i != 0)
            {
                tutorialPanels[i].SetActive(false);
            }
        }
    }

    // Set the button visibility
    void SetButtonVisibility(bool visible)
    {
        // Check if the button reference is not null
        if (button != null)
        {
            // Set the button's visibility
            button.gameObject.SetActive(visible);
        }
    }
}
