using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BHellAudio : MonoBehaviour
{
    public AudioSource BGMusic;
    public AudioClip BGMLose;

    private void Awake()
    {
        BGMusic = GetComponent<AudioSource>();
    }

    public void startBGM(bool b)
    {
        if (b)
        {
            BGMusic.Play();
        }
        else
        {
            BGMusic.Stop();
        }
    }

    public void playResults()
    {
        if(BGMusic.isPlaying)
        {
            BGMusic.Stop();

            BGMusic.PlayOneShot(BGMLose);
        }

    }

}
