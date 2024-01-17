using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    public string levelToLoad = "Game"; // Name of the level to load after the video ends
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd; // Subscribe to the event when the video ends
        float videoLength = (float)videoPlayer.clip.length; // Get the length of the video
        Invoke("LoadLevelAfterVideo", videoLength); // Load the level after the video duration
    }

    void LoadLevelAfterVideo()
    {
        SceneManager.LoadScene(levelToLoad); // Load the designated level
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Called when the video reaches its end
        LoadLevelAfterVideo(); // Load the level when the video ends
    }
}
