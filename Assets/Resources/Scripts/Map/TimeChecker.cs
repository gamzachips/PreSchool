using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeChecker : MonoBehaviour
{
    [SerializeField]
    float totalTime = 97f;

    float nowTime = 0f;
    public float NowTime { get { return nowTime; } }
    void Start()
    {
        nowTime = 0f;
    }

    void Update()
    {
        nowTime += Time.deltaTime;

        if(nowTime >= totalTime)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
