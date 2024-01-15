using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeSettings : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the UI Slider
    public AudioSource audioSource; // Reference to the AudioSource you want to control

    private const float maxVolume = 100f; // Maximum volume value

    // Start is called before the first frame update
    void Start()
    {
        // Check if the slider and audio source references are set
        if (volumeSlider != null && audioSource != null)
        {
            // Load the saved volume (if any)
            float savedVolume = PlayerPrefs.GetFloat("Volume", 100f) / maxVolume;
            volumeSlider.value = savedVolume;

            // Set the initial volume
            audioSource.volume = savedVolume;

            // Add a listener to the slider's value changed event
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }
        else
        {
            Debug.LogError("Slider or AudioSource references not set.");
        }
    }

    // Function to be called when the volume slider value changes
    void OnVolumeChanged(float volume)
    {
        // Convert the slider value to a percentage (0 to 1 range)
        float normalizedVolume = volume / maxVolume;

        // Set the volume of the audio source
        audioSource.volume = normalizedVolume;

        // Save the volume for future sessions
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}

