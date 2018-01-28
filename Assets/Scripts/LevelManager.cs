using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

	private void Awake ()
    {
		if (!instance)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
	}
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private IEnumerator LoadNextLevelAfter(float t)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
