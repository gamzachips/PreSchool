using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LayserManager : MonoBehaviour
{
    TimeChecker timeChecker;

    public float[] APatternTime;
    public float[] BPatternTime;
    public float[] CPatternTime;
    public float[] DPatternTime;
    public float[] FPatternTime;
    public float[] GPatternTime;

    public Vector2[] APattern;
    public Vector2[] BPattern;
    public Vector2[] CPattern;
    public Vector2[] DPattern;
    public Vector2[] FPattern;
    public Vector2[] GPattern;

    public enum LineLayserPattern
    {
        APattern,
        BPattern,
        CPattern,
        DPattern,
        FPattern,
        GPattern
    };

    pu

    void Start()
    {
        timeChecker = GameObject.Find("TimeChecker").GetComponent<TimeChecker>();

        APattern = new Vector2[5];
        BPattern = new Vector2[4];
        CPattern = new Vector2[3];
        DPattern = new Vector2[5];
        FPattern = new Vector2[4];
        GPattern = new Vector2[4];
    }

    void Update()
    {
        float time = timeChecker.NowTime;
        //A패턴 시간 검사
        foreach(int patternTime in APatternTime)
        {
            if( Mathf.Abs(time - patternTime) < Time.deltaTime)
            {
                //레이저 출력

            }
        }
        //B패턴 시간 검사
        foreach (int patternTime in BPatternTime)
        {
            if (Mathf.Abs(time - patternTime) < Time.deltaTime)
            {
                //레이저 출력

            }
        }
        //C패턴 시간 검사
        foreach (int patternTime in CPatternTime)
        {
            if (Mathf.Abs(time - patternTime) < Time.deltaTime)
            {
                //레이저 출력

            }
        }
        //D패턴 비트 검사
        foreach (int patternTime in DPatternTime)
        {
            if (Mathf.Abs(time - patternTime) < Time.deltaTime)
            {
                //레이저 출력

            }
        }

        //F패턴 시간 검사
        foreach (int patternTime in FPatternTime)
        {
            if (Mathf.Abs(time - patternTime) < Time.deltaTime)
            {
                //레이저 출력

            }
        }
        //G패턴 시간 검사
        foreach (int patternTime in GPatternTime)
        {
            if (Mathf.Abs(time - patternTime) < Time.deltaTime)
            {
                //레이저 출력

            }
        }
    }
}
