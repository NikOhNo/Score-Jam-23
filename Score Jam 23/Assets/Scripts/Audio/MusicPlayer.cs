using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    AudioSource myAudioSource;
    string currScene;
    string playingMusicScene;

    [SerializeField]
    AudioClip menuSong;

    [SerializeField]
    AudioClip gameplaySong;

    [SerializeField]
    AudioClip loseSong;

    private void Awake()
    {
        int singletonCount = FindObjectsOfType<MusicPlayer>().Length;
        if (singletonCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            myAudioSource = GetComponent<AudioSource>();
            myAudioSource.Play();
        }
    }

    public void UpdateMusic(string scene)
    {
        if (scene == "MainMenu" || scene == "Credits" || scene == "Tutorial" || scene == "Leaderboard")
        {
            currScene = "Menu";
        }
        else if (scene == "Gameplay")
        {
            currScene = "Gameplay";
        }

        PlayRightMusic(currScene);
    }

    private void PlayRightMusic(string currScene)
    {
        AudioClip oldSong = myAudioSource.clip;

        if (currScene == "Menu")
        {
            myAudioSource.clip = menuSong;
        }
        else if (currScene == "Gameplay")
        {
            myAudioSource.clip = gameplaySong;
        }

        if(oldSong != myAudioSource.clip)
        {
            Debug.Log(oldSong);
            Debug.Log(myAudioSource.clip);
            myAudioSource.Play();
        }
    }

    public void PlayLoseMusic()
    {
        myAudioSource.clip = loseSong;
        myAudioSource.Play();
    }
}
