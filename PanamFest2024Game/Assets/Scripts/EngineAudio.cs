using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineAudio : MonoBehaviour
{
  public AudioSource boatEngine;

    void Start()
    {
        boatEngine = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!boatEngine.isPlaying)
            {
                boatEngine.Play();
            }
        }
        else
        {
            if (boatEngine.isPlaying)
            {
                boatEngine.Stop();
            }
        }
    }
}
