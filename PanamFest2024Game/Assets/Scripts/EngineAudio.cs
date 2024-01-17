using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineAudio : MonoBehaviour
{
  public AudioSource boatSound;

    void Start()
    {
        boatSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!boatSound.isPlaying)
            {
                boatSound.Play();
            }
        }
        else
        {
            if (boatSound.isPlaying)
            {
                boatSound.Stop();
            }
        }
    }
}
