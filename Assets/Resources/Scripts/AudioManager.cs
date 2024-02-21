using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Serializable]
    public class MusicTimings
    {
        public float[] elements;
    }
    public MusicTimings[] musicTimings;

    [Serializable]
    public class MusicClips
    {
        public AudioClip[] elements;
    }
    public MusicClips[] musicClips;

    [SerializeField]
    List<AudioSource> musicSources;

    [SerializeField]
    AudioSource itemSoundSource;

    [SerializeField]
    AudioClip itemSoundClip;

    TimeChecker timeChecker;
    
    private void Start()
    {
        timeChecker = GameObject.Find("TimeChecker").GetComponent<TimeChecker>();
        //itemSoundSource.clip = itemSoundClip;
    }

    void Update()
    {
        for(int i = 0; i < musicTimings.Length; i++)
        {
            for (int j = 0; j < musicTimings[i].elements[j]; j++)
            {
                //음악을 시작할 시간이면
                if (Mathf.Abs(musicTimings[i].elements[j] - timeChecker.NowTime) < Time.deltaTime)
                {
                    //음악을 올린다
                    musicSources[i].clip = musicClips[i].elements[j];
                    musicSources[i].Play();
                }

            }
        }
    }

    public void PlayItemSound()
    {
        itemSoundSource.Play();
    }
}
