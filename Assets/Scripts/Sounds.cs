using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds: MonoBehaviour
{
    public AudioClip[] clips;

    public void PlaySoundScene(int clipIdx)
    {
		AudioSource.PlayClipAtPoint(clips[clipIdx], Utility.CAMERA_POSITION_SCENES);
    }
	public void PlaySoundCutScene(int clipIdx)
	{
		AudioSource.PlayClipAtPoint(clips[clipIdx], Utility.CAMERA_POSITION_CUTSCENES);
	}
	public void LoopSound(int clipIdx)
	{
		GetComponent<AudioSource>().clip = clips[clipIdx];
		GetComponent<AudioSource>().loop = true;
		GetComponent<AudioSource>().Play();
	}
    public void StopSound()
    {
        GetComponent<AudioSource>().Stop();
    }
}
