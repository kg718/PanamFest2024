using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSound : MonoBehaviour
{
    public AudioSource Splash;

    void Start()
    {
        Splash = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (!Splash.isPlaying)
            {
                Splash.Play();
            }
        }
        else
        {
            if (Splash.isPlaying)
            {
                Splash.Stop();
            }
        }
    }
}
