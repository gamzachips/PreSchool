using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    static AudioManager instance;
    public static AudioManager Instance { get { Init();  return instance; } }

    static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("AudioManager");
            if (go == null)
            {
                go = new GameObject { name = "AudioManager" };
                go.AddComponent<AudioManager>();
                
            }
            DontDestroyOnLoad(go);
            instance = go.GetComponent<AudioManager>();
        }
    }

    AudioSource musicSource;
    AudioSource effectSoundSource;

    AudioClip mainMusicClip;
    AudioClip gameMusicClip;
    AudioClip tutorialMusicClip;
    AudioClip itemSoundClip;
    AudioClip buttonSoundClip;

    public void Awake()
    {
        Init();
        instance.MakeAduioSurce();
        instance.LoadAudios();
    }

    private void MakeAduioSurce()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        effectSoundSource = gameObject.AddComponent<AudioSource>();

        musicSource.playOnAwake = false;
        effectSoundSource.playOnAwake = false;
        effectSoundSource.volume = 0.5f;
    }

    private void LoadAudios()
    {
        mainMusicClip = Resources.Load<AudioClip>("Audios/MainMusic");
        gameMusicClip = Resources.Load<AudioClip>("Audios/Game2");
        itemSoundClip = Resources.Load<AudioClip>("Audios/ItemPickUp");
        buttonSoundClip = Resources.Load<AudioClip>("Audios/ButtonClick");
        tutorialMusicClip = Resources.Load<AudioClip>("Audios/Tutorial");
    }

    public void PlayMainMusic()
    {
        musicSource.clip = mainMusicClip;
        musicSource.loop = true;
        musicSource.mute = false;
        musicSource.Play();
    }
    public void PlayGameMusic()
    {
        musicSource.clip = gameMusicClip;
        musicSource.mute = false;
        musicSource.loop = false;
        musicSource.Play();
    }

    public void PlayTutorialMusic()
    {
        musicSource.clip = tutorialMusicClip;
        musicSource.mute = false;
        musicSource.loop = false;
        musicSource.Play();
    }

    public void MuteMusic()
    {
        musicSource.mute = true;
    }

    public void PlayButtonSound()
    {
        effectSoundSource.clip = buttonSoundClip;
        effectSoundSource.Play();
    }

    public void PlayItemSound()
    {
        effectSoundSource.clip = itemSoundClip;
        effectSoundSource.Play();
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void ContinueMusic()
    {
        musicSource.Play();
    }
}