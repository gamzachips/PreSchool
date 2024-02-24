using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum GradeType
{
    S, A, B, C, F
}

public class ScoreSystem : MonoBehaviour
{
    //ΩÃ±€≈Ê
    static ScoreSystem instance;
    public static ScoreSystem Instance { get { Init(); return instance; } }

    static void Init()
    {
        if(instance == null)
        {
            GameObject go = GameObject.Find("ScoreSystem");
            if(go == null)
            {
                go = new GameObject { name = "ScoreSystem" };
                go.AddComponent<ScoreSystem>();
            }
            DontDestroyOnLoad(go);
            instance = go.GetComponent<ScoreSystem>();
        }
    }



    [SerializeField]
    int maxScore = 33000;

    GradeType grade = GradeType.C;
    public GradeType Grade { get { return grade; } set { grade = value; } }
    int score = 0;

    public int scoreItem500 = 0;
    public int scoreItem1000 = 0;
    public int scoreItem1500 = 0;

    public int Score { get { return score; } }
    public void AddScore(int amount)
    {
        score += amount;
        SetGrade();
    }
    public void Start()
    {
        Init();
    }

    
    private void SetGrade()
    {
        if (score < 4950)
        {
            grade = GradeType.C;
        }
        else if (score < 13200)
        {
            grade = GradeType.B;
        }
        else if (score < 21450)
        {
            grade = GradeType.A;
        }
        else
        {
            grade = GradeType.S;
        }

    }

    private void Update()
    {

        GameObject player = GameObject.Find("Player");
        if (player != null && player.GetComponent<PlayerLife>() != null)
        {
            if (player.GetComponent<PlayerLife>().playerstate == PlayerLife.PlayerState.die)
            {
                grade = GradeType.F;
            }
        }

    }

    public void Reset()
    {
        scoreItem500 = 0;
        scoreItem1000 = 0;
        scoreItem1500 = 0;
        score = 0;
        grade = GradeType.C;
    }
}
