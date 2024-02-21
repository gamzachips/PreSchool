using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChecker : MonoBehaviour
{
    float nowTime = 0f;
    public float NowTime { get { return nowTime; } }
    void Start()
    {
        nowTime = 0f;
    }

    void Update()
    {
        nowTime += Time.deltaTime;
    }
}
