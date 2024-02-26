using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //싱글톤
    static AudioManager instance;
    public static AudioManager Instance { get { Init(); return instance; } }

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
    AudioClip itemSoundClip;
    AudioClip buttonSoundClip;

    private void Start()
    {
        Init();
        
        //오디오 소스 생성
        musicSource = gameObject.AddComponent<AudioSource>();
        effectSoundSource = gameObject.AddComponent<AudioSource>();

        musicSource.playOnAwake = false;
        effectSoundSource.playOnAwake = false;
        effectSoundSource.volume = 0.5f;

        LoadAudios();
    }

    private void LoadAudios()
    {
        mainMusicClip = Resources.Load<AudioClip>("Audios/MainMusic");
        gameMusicClip = Resources.Load<AudioClip>("Audios/Game2");
        itemSoundClip = Resources.Load<AudioClip>("Audios/ItemPickUp");
        buttonSoundClip = Resources.Load<AudioClip>("Audios/ButtonClick");
    }

    public void PlayMainMusic()
    {
        musicSource.clip = mainMusicClip;
        musicSource.loop = true;
        musicSource.Play();
    }
    public void PlayGameMusic()
    {
        musicSource.clip = gameMusicClip;
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

}