using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        FindObjectOfType<MusicPlayer>().UpdateMusic(SceneManager.GetSceneAt(0).name);

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void LoadNextScene()
    {

        Time.timeScale = 1f;
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
        FindObjectOfType<MusicPlayer>().UpdateMusic(SceneManager.GetSceneAt(scene.buildIndex + 1).name);
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
    public void ReloadScene()
    {
        if(FindObjectOfType<ScoreManager>())
        {
            FindObjectOfType<ScoreManager>().ResetScore();
            FindObjectOfType<ScoreManager>().ResetGameOver();
        }

        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
        FindObjectOfType<MusicPlayer>().UpdateMusic(SceneManager.GetSceneAt(scene.buildIndex).name);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSceneName(string sceneName)
    {
        if (sceneName != "Leaderboard")
        {
            if (FindObjectOfType<ScoreManager>())
            {
                FindObjectOfType<ScoreManager>().ResetScore();
                FindObjectOfType<ScoreManager>().ResetGameOver();
            }
        }

        SceneManager.LoadScene(sceneName);
        FindObjectOfType<MusicPlayer>().UpdateMusic(sceneName);
        Time.timeScale = 1f;
    }
}
