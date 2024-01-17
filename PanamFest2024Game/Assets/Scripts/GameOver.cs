using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverPanel;

    
    public void GameOverScreen()
    {
        GameOverPanel.SetActive(true);
    }
}
