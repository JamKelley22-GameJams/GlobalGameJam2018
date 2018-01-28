using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuMusic : MonoBehaviour
{
    static bool AudioBegin = false;
    public AudioClip menuMusicClip;
    public AudioSource menuMusicSource;

    void Awake()
    {
        if (!AudioBegin)
        {
            menuMusicSource.clip = menuMusicClip;
            menuMusicSource.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        } else {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        if (Application.loadedLevelName == "test")
        {
            menuMusicSource.Stop();
            AudioBegin = false;
            Destroy(gameObject);
        }
        
    }
}

