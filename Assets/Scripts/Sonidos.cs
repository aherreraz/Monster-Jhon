using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour
{
    public AudioClip[] clips;

    public void PlaySound(int clipIdx)
    {
        GetComponent<AudioSource>().clip = clips[clipIdx];
        GetComponent<AudioSource>().Play();
    }
    public void StopSound()
    {
        GetComponent<AudioSource>().Stop();
    }
}
