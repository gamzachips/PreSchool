using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    List<List<float>> musicTimings = new List<List<float>>();
    
    [SerializeField]
    List<List<AudioClip>> musicClips = new List<List<AudioClip>>();

    [SerializeField]
    List<AudioSource> musicSources = new List<AudioSource>();

    [SerializeField]
    AudioSource itemSoundSource;

    [SerializeField]
    AudioClip itemSoundClip;

    TimeChecker timeChecker;
    
    [SerializeField]
    float timeBox = 8.0f;

    private void Start()
    {
        timeChecker = GameObject.Find("TimeChecker").GetComponent<TimeChecker>();
        itemSoundSource.clip = itemSoundClip;
    }

    void Update()
    {
        for(int i = 0; i < musicTimings.Count; i++)
        {
            for (int j = 0; j < musicTimings[i].Count; j++)
            {
                //음악을 시작할 시간이면
                if (Mathf.Abs(musicTimings[i][j] - timeChecker.NowTime) < Time.deltaTime)
                {
                    //음악을 올린다
                    musicSources[i].clip = musicClips[i][j];
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
