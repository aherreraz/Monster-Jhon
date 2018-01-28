using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public AudioClip[] levelMusicArray;
    public float[] timers;

	private void Awake ()
    {
		if (!instance)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
            Destroy(this);
	}
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void LoadNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SetMusic(nextLevel);
        SceneManager.LoadScene(nextLevel);
    }
    public void ReloadLevelWithDelay(float t)
    {
        StartCoroutine(ReloadLevel(t));
    }
    public void LoadNextLevelWithDelay(float t)
    {
        StartCoroutine(LoadNextLevelAfter(t));
    }
    private IEnumerator ReloadLevel(float t)
    {
        yield return new WaitForSeconds(t);
        int level = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(level);
    }
    private IEnumerator LoadNextLevelAfter(float t)
    {
        yield return new WaitForSeconds(t);
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SetMusic(nextLevel);
        SceneManager.LoadScene(nextLevel);
    }
    private void SetMusic(int sceneIndex)
    {
        if (levelMusicArray[sceneIndex])
        {
            if (!GetComponent<AudioSource>().clip || levelMusicArray[sceneIndex].name != GetComponent<AudioSource>().clip.name)
            {
                SetTrack(sceneIndex);
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
    }
    private void SetTrack (int sceneIndex)
    {
        GetComponent<AudioSource>().clip = levelMusicArray[sceneIndex];
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().Play();
    }
    public float GetTimer()
    {
        return timers[SceneManager.GetActiveScene().buildIndex];
    }
}
