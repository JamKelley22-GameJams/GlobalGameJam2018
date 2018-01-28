using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LevelMusic : MonoBehaviour
{
    static bool AudioBegin = false;
    public AudioClip levelMusicClip;
    public AudioSource levelMusicSource;

    void Awake()
    {
        if (!AudioBegin)
        {
            levelMusicSource.clip = levelMusicClip;
            levelMusicSource.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
    
    void Update()
    {
       if (Application.loadedLevelName == "MainMenu"){
          levelMusicSource.Stop();
          AudioBegin = false;
            Destroy(gameObject);
        }
    }
}

