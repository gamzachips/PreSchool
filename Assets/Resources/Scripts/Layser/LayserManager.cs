using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class LayserManager : MonoBehaviour
{
    TimeChecker timeChecker;

    public float[] APatternTimer;
    public float[] BPatternTimer;
    public float[] CPatternTimer;
    public float[] DPatternTimer;
    public float[] FPatternTimer;
    public float[] GPatternTimer;

    public bool[] bAPatternTimer;
    public bool[] bBPatternTimer;
    public bool[] bCPatternTimer;
    public bool[] bDPatternTimer;
    public bool[] bFPatternTimer;
    public bool[] bGPatternTimer;

    public Vector2 APatternFirstPosition;
    public Vector2 BPatternFirstPosition;
    public Vector2 CPatternFirstPosition;
    public Vector2 DPatternFirstPosition;
    public Vector2 FPatternFirstPosition;
    public Vector2 GPatternFirstPosition;

    public Vector2[] APatternPosition;
    public Vector2[] BPatternPosition;
    public Vector2[] CPatternPosition;
    public Vector2[] DPatternPosition;
    public Vector2[] FPatternPosition;
    public Vector2[] GPatternPosition;

    public LineLayser[] ALayserObj;
    public LineLayser[] BLayserObj;
    public LineLayser[] CLayserObj;
    public LineLayser[] DLayserObj;
    public LineLayser[] FLayserObj;
    public LineLayser[] GLayserObj;

    // 시간 체크
    private float MusicTime;
    private int StartInx = 0;
    private int  EndInx = 0;

    //public enum LineLayserPattern
    //{
    //    None,
    //    APattern,
    //    BPattern,
    //    CPattern,
    //    DPattern,
    //    FPattern,
    //    GPattern,
    //    AFPattern,
    //    CDPattern
    //};

    void Start()
    {
        timeChecker = GameObject.Find("TimeChecker").GetComponent<TimeChecker>();

        APatternPosition = new Vector2[5];
        BPatternPosition = new Vector2[4];
        CPatternPosition = new Vector2[3];
        DPatternPosition = new Vector2[5];
        FPatternPosition = new Vector2[4];
        GPatternPosition = new Vector2[4];

        bAPatternTimer = new bool[5];
        bBPatternTimer = new bool[4];
        bCPatternTimer = new bool[3];
        bDPatternTimer = new bool[5];
        bFPatternTimer = new bool[4];
        bGPatternTimer = new bool[4];

        APatternTimer = new float[10];
        BPatternTimer = new float[10];
        CPatternTimer = new float[10];
        DPatternTimer = new float[10];
        FPatternTimer = new float[10];
        GPatternTimer = new float[10];

        ALayserObj = new LineLayser[5];
        BLayserObj = new LineLayser[4];
        CLayserObj = new LineLayser[3];
        DLayserObj = new LineLayser[5];
        FLayserObj = new LineLayser[4];
        GLayserObj = new LineLayser[4];


        for (int i = 0; i < 5; i++)
        {
            bAPatternTimer[i] = false;
            bDPatternTimer[i] = false;
            if(i < 3)
            {
                bCPatternTimer[i] = false;
            }
            else if (i < 4) 
            {
                bFPatternTimer[i] = false;
                bGPatternTimer[i] = false;
            }
        }

        //  최대 레이저 수
        //  LayserObj = new LineLayser[MaxIndex];
        //  LayserObj = new LineLayser[30];
    }


    void Update()
    {
        MusicTime += Time.deltaTime;

        TimeCheck();
    }

    public void TimeCheck()
    {
        float time = timeChecker.NowTime;


        //A패턴 시간 검사
        for(int i = 0; i < bAPatternTimer.Length; i++)
        {
            if (MusicTime > APatternTimer[i]
                && !(bAPatternTimer[i]))
            {
                LayserAPattern();
            }
            break;
        }

        //B패턴 시간 검사
        for (int i = 0; i < bBPatternTimer.Length; i++)
        {
            if (MusicTime > BPatternTimer[i]
                && !(bBPatternTimer[i]))
            {
                LayserBPattern();
            }
            break;
        }

        //C패턴 시간 검사
        for (int i = 0; i < bCPatternTimer.Length; i++)
        {
            if (MusicTime > CPatternTimer[i]
                && !(bCPatternTimer[i]))
            {
                LayserCPattern();
            }
            break;
        }

        //D패턴 시간 검사
        for (int i = 0; i < bDPatternTimer.Length; i++)
        {
            if (MusicTime > DPatternTimer[i]
                && !(bDPatternTimer[i]))
            {
                LayserCPattern();
            }
            break;
        }

        //F패턴 시간 검사
        for (int i = 0; i < bFPatternTimer.Length; i++)
        {
            if (MusicTime > FPatternTimer[i]
                && !(bFPatternTimer[i]))
            {
                LayserCPattern();
            }
            break;
        }

        //G패턴 시간 검사
        for (int i = 0; i < bGPatternTimer.Length; i++)
        {
            if (MusicTime > GPatternTimer[i]
                && !(bGPatternTimer[i]))
            {
                LayserCPattern();
            }
            break;
        }
    }

    public void LayserNone()
    {
        Vector2 WithOutWorld = new Vector2(-7000f, 6000f);
        for (int i = 0; i < 5; i++)
        {
            ALayserObj[i].SelectLineLayserSprite(WithOutWorld, 200f, 0);
            DLayserObj[i].SelectLineLayserSprite(WithOutWorld, 200f, 0);
            if (i < 3)
            {
                CLayserObj[i].SelectLineLayserSprite(WithOutWorld, 200f, 0);
            }
            else if (i < 4)
            {
                BLayserObj[i].SelectLineLayserSprite(WithOutWorld, 200f, 0);
                FLayserObj[i].SelectLineLayserSprite(WithOutWorld, 200f, 0);
                GLayserObj[i].SelectLineLayserSprite(WithOutWorld, 200f, 0);
            }
        }
    }

    public void LayserAPattern()
    {
        ALayserObj[0].SelectLineLayserSprite(APatternPosition[0], 8f, 0);
        ALayserObj[1].SelectLineLayserSprite(APatternPosition[0], 8.05f, 0);
        ALayserObj[2].SelectLineLayserSprite(APatternPosition[0], 8.1f, 0);
        ALayserObj[3].SelectLineLayserSprite(APatternPosition[0], 8.15f, 0);
        ALayserObj[4].SelectLineLayserSprite(APatternPosition[0], 8.2f, 0);
    }

    public void LayserBPattern()
    {
        BLayserObj[0].SelectLineLayserSprite(BPatternPosition[0], 16f, 0);
        BLayserObj[1].SelectLineLayserSprite(BPatternPosition[0], 16.05f, 0);
        BLayserObj[2].SelectLineLayserSprite(BPatternPosition[0], 16.1f, 0);
        BLayserObj[3].SelectLineLayserSprite(BPatternPosition[0], 16.15f, 0);
        BLayserObj[4].SelectLineLayserSprite(BPatternPosition[0], 16.2f, 0);
    }

    public void LayserCPattern()
    {
        CLayserObj[0].SelectLineLayserSprite(CPatternPosition[0], 40f, 0);
        CLayserObj[1].SelectLineLayserSprite(CPatternPosition[0], 40.05f, 0);
        CLayserObj[2].SelectLineLayserSprite(CPatternPosition[0], 40.1f, 0);
        CLayserObj[3].SelectLineLayserSprite(CPatternPosition[0], 40.15f, 0);
        CLayserObj[4].SelectLineLayserSprite(CPatternPosition[0], 40.2f, 0);
    }
    public void LayserDPattern()
    {
        DLayserObj[0].SelectLineLayserSprite(DPatternPosition[0], 24f, 0);
        DLayserObj[1].SelectLineLayserSprite(DPatternPosition[0], 24.05f, 0);
        DLayserObj[2].SelectLineLayserSprite(DPatternPosition[0], 24.1f, 0);
        DLayserObj[3].SelectLineLayserSprite(DPatternPosition[0], 24.15f, 0);
        DLayserObj[4].SelectLineLayserSprite(DPatternPosition[0], 24.2f, 0);
    }
    public void LayserFPattern()
    {
        FLayserObj[0].SelectLineLayserSprite(FPatternPosition[0], 64f, 0);
        FLayserObj[1].SelectLineLayserSprite(FPatternPosition[0], 64.05f, 0);
        FLayserObj[2].SelectLineLayserSprite(FPatternPosition[0], 64.1f, 0);
        FLayserObj[3].SelectLineLayserSprite(FPatternPosition[0], 64.15f, 0);
        FLayserObj[4].SelectLineLayserSprite(FPatternPosition[0], 64.2f, 0);
    }

    public void LayserGPattern()
    {
        GLayserObj[0].SelectLineLayserSprite(GPatternPosition[0], 56f, 0);
        GLayserObj[1].SelectLineLayserSprite(GPatternPosition[0], 56.05f, 0);
        GLayserObj[2].SelectLineLayserSprite(GPatternPosition[0], 56.1f, 0);
        GLayserObj[3].SelectLineLayserSprite(GPatternPosition[0], 56.15f, 0);
        GLayserObj[4].SelectLineLayserSprite(GPatternPosition[0], 56.2f, 0);
    }
}
