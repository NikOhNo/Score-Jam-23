using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
    public void ReloadScene()
    {
        if(FindObjectOfType<ScoreManager>())
        {
            FindObjectOfType<ScoreManager>().ResetScore();
            FindObjectOfType<ScoreManager>().ResetGameOver();
        }

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSceneName(string sceneName)
    {
        if (FindObjectOfType<ScoreManager>())
        {
            FindObjectOfType<ScoreManager>().ResetScore();
            FindObjectOfType<ScoreManager>().ResetGameOver();
        }

        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}
