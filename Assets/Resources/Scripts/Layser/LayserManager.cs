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

    public float[] APatternRotation;
    public float[] BPatternRotation;
    public float[] CPatternRotation;
    public float[] DPatternRotation;
    public float[] FPatternRotation;
    public float[] GPatternRotation;

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

        APatternPosition = new Vector2[25];
        BPatternPosition = new Vector2[20];
        CPatternPosition = new Vector2[6];
        DPatternPosition = new Vector2[20];
        FPatternPosition = new Vector2[8];
        GPatternPosition = new Vector2[4];

        bAPatternTimer = new bool[25];
        bBPatternTimer = new bool[20];
        bCPatternTimer = new bool[6];
        bDPatternTimer = new bool[20];
        bFPatternTimer = new bool[8];
        bGPatternTimer = new bool[4];

        APatternTimer = new float[4];
        BPatternTimer = new float[5];
        CPatternTimer = new float[2];
        DPatternTimer = new float[4];
        FPatternTimer = new float[2];
        GPatternTimer = new float[1];

        APatternRotation = new float[25];
        BPatternRotation = new float[20];
        CPatternRotation = new float[6];
        DPatternRotation = new float[20];
        FPatternRotation = new float[8];
        GPatternRotation = new float[4];

        //ALayserObj = new LineLayser[25];
        //BLayserObj = new LineLayser[20];
        //CLayserObj = new LineLayser[6];
        //DLayserObj = new LineLayser[20];
        //FLayserObj = new LineLayser[8];
        //GLayserObj = new LineLayser[4];

        APatternTimer[0] = 8f;
        APatternTimer[1] = 8.05f;
        APatternTimer[2] = 8.1f;
        APatternTimer[3] = 8.15f;
        APatternTimer[4] = 8.2f;
        APatternTimer[5] = 16f;
        APatternTimer[6] = 16.05f;
        APatternTimer[7] = 16.1f;
        APatternTimer[8] = 16.15f;
        APatternTimer[9] = 16.2f;
        APatternTimer[10] = 24f;
        APatternTimer[11] = 24.05f;
        APatternTimer[12] = 24.1f;
        APatternTimer[13] = 24.15f;
        APatternTimer[14] = 24.2f;
        APatternTimer[15] = 32f;
        APatternTimer[16] = 32.05f;
        APatternTimer[17] = 32.1f;
        APatternTimer[18] = 32.15f;
        APatternTimer[19] = 32.2f;
        APatternTimer[20] = 88f;
        APatternTimer[21] = 88.05f;
        APatternTimer[22] = 88.1f;
        APatternTimer[23] = 88.15f;
        APatternTimer[24] = 88.2f;

        BPatternTimer[0] = 16f;
        BPatternTimer[1] = 16.05f;
        BPatternTimer[2] = 16.1f;
        BPatternTimer[3] = 16.15f;
        BPatternTimer[4] = 24.2f;
        BPatternTimer[5] = 24f;
        BPatternTimer[6] = 24.05f;
        BPatternTimer[7] = 24.1f;
        BPatternTimer[8] = 32.15f;
        BPatternTimer[9] = 32.2f;
        BPatternTimer[10] = 32f;
        BPatternTimer[11] = 32.05f;
        BPatternTimer[12] = 56.1f;
        BPatternTimer[13] = 56.15f;
        BPatternTimer[14] = 56.2f;
        BPatternTimer[15] = 56f;
        BPatternTimer[16] = 72.05f;
        BPatternTimer[17] = 72.1f;
        BPatternTimer[18] = 72.15f;
        BPatternTimer[19] = 72.2f;

        CPatternTimer[0] = 40f;
        CPatternTimer[1] = 40.05f;
        CPatternTimer[2] = 40.1f;
        CPatternTimer[3] = 48.15f;
        CPatternTimer[4] = 48.2f;
        CPatternTimer[5] = 48.2f;

        DPatternTimer[0] = 24f;
        DPatternTimer[1] = 24.05f;
        DPatternTimer[2] = 24.1f;
        DPatternTimer[3] = 24.15f;
        DPatternTimer[4] = 24.2f;
        DPatternTimer[5] = 40f;
        DPatternTimer[6] = 40.05f;
        DPatternTimer[7] = 40.1f;
        DPatternTimer[8] = 40.15f;
        DPatternTimer[9] = 40.2f;
        DPatternTimer[10] = 72f;
        DPatternTimer[11] = 72.05f;
        DPatternTimer[12] = 72.1f;
        DPatternTimer[13] = 72.15f;
        DPatternTimer[14] = 72.2f;
        DPatternTimer[15] = 80f;
        DPatternTimer[16] = 80.05f;
        DPatternTimer[17] = 80.1f;
        DPatternTimer[18] = 80.15f;
        DPatternTimer[19] = 80.2f;

        FPatternTimer[0] = 32f;
        FPatternTimer[1] = 32.05f;
        FPatternTimer[2] = 32.1f;
        FPatternTimer[3] = 32.15f;
        FPatternTimer[4] = 72.2f;
        FPatternTimer[5] = 72.05f;
        FPatternTimer[6] = 72.1f;
        FPatternTimer[7] = 72.15f;

        GPatternTimer[0] = 64f;
        GPatternTimer[1] = 64.05f;
        GPatternTimer[2] = 64.1f;
        GPatternTimer[3] = 64.15f;

        //포지션
        
        APatternPosition[0] = new Vector2(3.27f, 2.58f);
        APatternPosition[1] = new Vector2(2.62f, 1.4f);
        APatternPosition[2] = new Vector2(1.87f, -3.03f);
        APatternPosition[3] = new Vector2(-1.27f, 3.26f);
        APatternPosition[4] = new Vector2(-1.75f, 2.09f);

        APatternRotation[0] = -214.9f;
        APatternRotation[1] = 415.0f;
        APatternRotation[2] = 361.3f;
        APatternRotation[3] = -319f;
        APatternRotation[4] = -496.2f;


        BPatternPosition[0] = new Vector2(0.18f, 2.85f);
        BPatternPosition[1] = new Vector2(0.18f, 0.64f);
        BPatternPosition[2] = new Vector2(0.18f, -1.29f);
        BPatternPosition[3] = new Vector2(0.18f, -3.19f);

        BPatternRotation[0] = 0f;
        BPatternRotation[1] = 0f;
        BPatternRotation[2] = 0f;
        BPatternRotation[3] = 0f;



        CPatternPosition[0] = new Vector2(0.18f, -3.19f);
        CPatternPosition[1] = new Vector2(0.46f, 1.48f);
        CPatternPosition[2] = new Vector2(-1.39f, 2.31f);

        CPatternRotation[0] = 40.27f;
        CPatternRotation[1] = 142.5f;
        CPatternRotation[2] = 219.2f;



        DPatternTimer[0] = 24f;
        DPatternTimer[1] = 24.05f;
        DPatternTimer[2] = 24.1f;
        DPatternTimer[3] = 24.15f;
        DPatternTimer[4] = 24.2f;

        DPatternRotation[0] = 0f;
        DPatternRotation[1] = 0f;
        DPatternRotation[2] = 0f;
        DPatternRotation[3] = 0f;
        DPatternRotation[4] = 0f;



        FPatternTimer[0] = 32f;
        FPatternTimer[1] = 32.05f;
        FPatternTimer[2] = 32.1f;
        FPatternTimer[3] = 32.15f;


        GPatternTimer[0] = 64f;
        GPatternTimer[1] = 64.05f;
        GPatternTimer[2] = 64.1f;
        GPatternTimer[3] = 64.15f;


        for (int i = 0; i < 5; i++)
        {
            bAPatternTimer[i] = false;
            bDPatternTimer[i] = false;
            if (i < 3)
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
        print(MusicTime.ToString());   
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
                break;
            }
        }

        //B패턴 시간 검사
        for (int i = 0; i < bBPatternTimer.Length; i++)
        {
            if (MusicTime > BPatternTimer[i]
                && !(bBPatternTimer[i]))
            {
                LayserBPattern();
                break;
            }
        }

        //C패턴 시간 검사
        for (int i = 0; i < bCPatternTimer.Length; i++)
        {
            if (MusicTime > CPatternTimer[i]
                && !(bCPatternTimer[i]))
            {
                LayserCPattern();
                break;
            }
        }

        //D패턴 시간 검사
        for (int i = 0; i < bDPatternTimer.Length; i++)
        {
            if (MusicTime > DPatternTimer[i]
                && !(bDPatternTimer[i]))
            {
                LayserDPattern();
                break;
            }
        }

        //F패턴 시간 검사
        for (int i = 0; i < bFPatternTimer.Length; i++)
        {
            if (MusicTime > FPatternTimer[i]
                && !(bFPatternTimer[i]))
            {
                LayserFPattern();
                break;
            }
        }

        //G패턴 시간 검사
        for (int i = 0; i < bGPatternTimer.Length; i++)
        {
            if (MusicTime > GPatternTimer[i]
                && !(bGPatternTimer[i]))
            {
                LayserGPattern();
                break;
            }
        }
    }

    public void LayserNone()
    {
        Vector2 WithOutWorld = new Vector2(0f, 0f);
        for (int i = 0; i < 5; i++)
        {
            ALayserObj[i].SelectLineLayserSprite(WithOutWorld, 200f, WithOutWorld);
            DLayserObj[i].SelectLineLayserSprite(WithOutWorld, 200f, WithOutWorld);
            if (i < 3)
            {
                CLayserObj[i].SelectLineLayserSprite(WithOutWorld, 200f, WithOutWorld);
            }
            else if (i < 4)
            {
                BLayserObj[i].SelectLineLayserSprite(WithOutWorld, 200f, WithOutWorld);
                FLayserObj[i].SelectLineLayserSprite(WithOutWorld, 200f, WithOutWorld);
                GLayserObj[i].SelectLineLayserSprite(WithOutWorld, 200f, WithOutWorld);
            }
        }
    }

    public void LayserAPattern()
    {
        APatternPosition[0] = new Vector2(0,0);
        ALayserObj[0].SelectLineLayserSprite(APatternPosition[0], 8f, APatternPosition[0]);
        ALayserObj[1].SelectLineLayserSprite(APatternPosition[1], 8.05f, APatternPosition[1]);
        ALayserObj[2].SelectLineLayserSprite(APatternPosition[2], 8.1f, APatternPosition[2]);
        ALayserObj[3].SelectLineLayserSprite(APatternPosition[3], 8.15f, APatternPosition[3]);
        ALayserObj[4].SelectLineLayserSprite(APatternPosition[4], 8.2f, APatternPosition[4]);

        ALayserObj[5].SelectLineLayserSprite(APatternPosition[5], 16f, APatternPosition[5]);
        ALayserObj[6].SelectLineLayserSprite(APatternPosition[6], 16.05f, APatternPosition[6]);
        ALayserObj[7].SelectLineLayserSprite(APatternPosition[7], 16.1f, APatternPosition[7]);
        ALayserObj[8].SelectLineLayserSprite(APatternPosition[8], 16.15f, APatternPosition[8]);
        ALayserObj[9].SelectLineLayserSprite(APatternPosition[9], 16.2f, APatternPosition[9]);

        ALayserObj[10].SelectLineLayserSprite(APatternPosition[10], 24f, APatternPosition[10]);
        ALayserObj[11].SelectLineLayserSprite(APatternPosition[11], 24.05f, APatternPosition[11]);
        ALayserObj[12].SelectLineLayserSprite(APatternPosition[12], 24.1f, APatternPosition[12]);
        ALayserObj[13].SelectLineLayserSprite(APatternPosition[13], 24.15f, APatternPosition[13]);
        ALayserObj[14].SelectLineLayserSprite(APatternPosition[14], 24.2f, APatternPosition[14]);

        ALayserObj[15].SelectLineLayserSprite(APatternPosition[15], 32f, APatternPosition[15]);
        ALayserObj[16].SelectLineLayserSprite(APatternPosition[16], 32.05f, APatternPosition[16]);
        ALayserObj[17].SelectLineLayserSprite(APatternPosition[17], 32.1f, APatternPosition[17]);
        ALayserObj[18].SelectLineLayserSprite(APatternPosition[18], 32.15f, APatternPosition[18]);
        ALayserObj[19].SelectLineLayserSprite(APatternPosition[19], 32.2f, APatternPosition[19]);

        ALayserObj[20].SelectLineLayserSprite(APatternPosition[20], 88f, APatternPosition[20]);
        ALayserObj[21].SelectLineLayserSprite(APatternPosition[21], 88.05f, APatternPosition[21]);
        ALayserObj[22].SelectLineLayserSprite(APatternPosition[22], 88.1f, APatternPosition[22]);
        ALayserObj[23].SelectLineLayserSprite(APatternPosition[23], 88.15f, APatternPosition[23]);
        ALayserObj[24].SelectLineLayserSprite(APatternPosition[24], 88.2f, APatternPosition[24]);
    }

    public void LayserBPattern()
    {
        BLayserObj[0].SelectLineLayserSprite(BPatternPosition[0], 16f, BPatternPosition[0]);
        BLayserObj[1].SelectLineLayserSprite(BPatternPosition[1], 16.05f, BPatternPosition[1]);
        BLayserObj[2].SelectLineLayserSprite(BPatternPosition[2], 16.1f, BPatternPosition[2]);
        BLayserObj[3].SelectLineLayserSprite(BPatternPosition[3], 16.15f, BPatternPosition[3]);

        BLayserObj[4].SelectLineLayserSprite(BPatternPosition[4], 24.2f, BPatternPosition[4]);
        BLayserObj[5].SelectLineLayserSprite(BPatternPosition[5], 24f, BPatternPosition[5]);
        BLayserObj[6].SelectLineLayserSprite(BPatternPosition[6], 24.05f, BPatternPosition[6]);
        BLayserObj[7].SelectLineLayserSprite(BPatternPosition[7], 24.1f, BPatternPosition[7]);

        BLayserObj[8].SelectLineLayserSprite(BPatternPosition[8], 32.15f, BPatternPosition[8]);
        BLayserObj[9].SelectLineLayserSprite(BPatternPosition[9], 32.2f, BPatternPosition[9]);
        BLayserObj[10].SelectLineLayserSprite(BPatternPosition[10], 32f, BPatternPosition[10]);
        BLayserObj[11].SelectLineLayserSprite(BPatternPosition[11], 32.05f, BPatternPosition[11]);

        BLayserObj[12].SelectLineLayserSprite(BPatternPosition[12], 56.1f, BPatternPosition[12]);
        BLayserObj[13].SelectLineLayserSprite(BPatternPosition[13], 56.15f, BPatternPosition[13]);
        BLayserObj[14].SelectLineLayserSprite(BPatternPosition[14], 56.2f, BPatternPosition[14]);
        BLayserObj[15].SelectLineLayserSprite(BPatternPosition[15], 56f, BPatternPosition[15]);

        BLayserObj[16].SelectLineLayserSprite(BPatternPosition[16], 72.05f, BPatternPosition[16]);
        BLayserObj[17].SelectLineLayserSprite(BPatternPosition[17], 72.1f, BPatternPosition[17]);
        BLayserObj[18].SelectLineLayserSprite(BPatternPosition[18], 72.15f, BPatternPosition[18]);
        BLayserObj[19].SelectLineLayserSprite(BPatternPosition[19], 72.2f, BPatternPosition[19]);

    }

    public void LayserCPattern()
    {
        CLayserObj[0].SelectLineLayserSprite(CPatternPosition[0], 40f, CPatternPosition[0]);
        CLayserObj[1].SelectLineLayserSprite(CPatternPosition[1], 40.05f, CPatternPosition[1]);
        CLayserObj[2].SelectLineLayserSprite(CPatternPosition[2], 40.1f, CPatternPosition[2]);

        CLayserObj[3].SelectLineLayserSprite(CPatternPosition[3], 48.15f, CPatternPosition[3]);
        CLayserObj[4].SelectLineLayserSprite(CPatternPosition[4], 48.2f, CPatternPosition[4]);
        CLayserObj[5].SelectLineLayserSprite(CPatternPosition[5], 48.2f, CPatternPosition[5]);

    }
    public void LayserDPattern()
    {
        DLayserObj[0].SelectLineLayserSprite(DPatternPosition[0], 24f, DPatternPosition[0]);
        DLayserObj[1].SelectLineLayserSprite(DPatternPosition[1], 24.05f, DPatternPosition[1]);
        DLayserObj[2].SelectLineLayserSprite(DPatternPosition[2], 24.1f,DPatternPosition[2]);
        DLayserObj[3].SelectLineLayserSprite(DPatternPosition[3], 24.15f, DPatternPosition[3]);
        DLayserObj[4].SelectLineLayserSprite(DPatternPosition[4], 24.2f, DPatternPosition[4]);

        DLayserObj[5].SelectLineLayserSprite(DPatternPosition[5], 40f, DPatternPosition[5]);
        DLayserObj[6].SelectLineLayserSprite(DPatternPosition[6], 40.05f, DPatternPosition[6]);
        DLayserObj[7].SelectLineLayserSprite(DPatternPosition[7], 40.1f, DPatternPosition[7]);
        DLayserObj[8].SelectLineLayserSprite(DPatternPosition[8], 40.15f, DPatternPosition[8]);
        DLayserObj[9].SelectLineLayserSprite(DPatternPosition[9], 40.2f, DPatternPosition[9]);

        DLayserObj[10].SelectLineLayserSprite(DPatternPosition[10], 72f, DPatternPosition[10]);
        DLayserObj[11].SelectLineLayserSprite(DPatternPosition[11], 72.05f, DPatternPosition[11]);
        DLayserObj[12].SelectLineLayserSprite(DPatternPosition[12], 72.1f, DPatternPosition[12]);
        DLayserObj[13].SelectLineLayserSprite(DPatternPosition[13], 72.15f, DPatternPosition[13]);
        DLayserObj[14].SelectLineLayserSprite(DPatternPosition[14], 72.2f, DPatternPosition[14]);

        DLayserObj[15].SelectLineLayserSprite(DPatternPosition[15], 80f, DPatternPosition[15]);
        DLayserObj[16].SelectLineLayserSprite(DPatternPosition[16], 80.05f, DPatternPosition[16]);
        DLayserObj[17].SelectLineLayserSprite(DPatternPosition[17], 80.1f, DPatternPosition[17]);
        DLayserObj[18].SelectLineLayserSprite(DPatternPosition[18], 80.15f, DPatternPosition[18]);
        DLayserObj[19].SelectLineLayserSprite(DPatternPosition[19], 80.2f, DPatternPosition[19]);
    }
    public void LayserFPattern()
    {
        FLayserObj[0].SelectLineLayserSprite(FPatternPosition[0], 32f, FPatternPosition[0]);
        FLayserObj[1].SelectLineLayserSprite(FPatternPosition[1], 32.05f, FPatternPosition[1]);
        FLayserObj[2].SelectLineLayserSprite(FPatternPosition[2], 32.1f, FPatternPosition[2]);
        FLayserObj[3].SelectLineLayserSprite(FPatternPosition[3], 32.15f, FPatternPosition[3]);

        FLayserObj[4].SelectLineLayserSprite(FPatternPosition[4], 72.2f, FPatternPosition[4]);
        FLayserObj[5].SelectLineLayserSprite(FPatternPosition[5], 72.05f, FPatternPosition[5]);
        FLayserObj[6].SelectLineLayserSprite(FPatternPosition[6], 72.1f, FPatternPosition[6]);
        FLayserObj[7].SelectLineLayserSprite(FPatternPosition[7], 72.15f, FPatternPosition[7]);
    }

    public void LayserGPattern()
    {
        GLayserObj[0].SelectLineLayserSprite(GPatternPosition[0], 64f, GPatternPosition[0]);
        GLayserObj[1].SelectLineLayserSprite(GPatternPosition[1], 64.05f, GPatternPosition[1]);
        GLayserObj[2].SelectLineLayserSprite(GPatternPosition[2], 64.1f, GPatternPosition[2]);
        GLayserObj[3].SelectLineLayserSprite(GPatternPosition[3], 64.15f, GPatternPosition[3]);
    }
}
