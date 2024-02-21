using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI gradeText;

    [SerializeField]
    int maxScore = 33000;

    char grade;
    int score = 0;

    public int Score { get { return score; } }
    public void AddScore(int amount)
    {
        score += amount;
    }

    public void Update()
    {
        float percentage = score / (float)maxScore;
        if (percentage < 0.25f)
        {
            grade = 'C';
        }
        else if(percentage < 0.5f)
        {
            grade = 'B';
        }
        else if(percentage < 0.75)
        {
            grade = 'A';
        }
        else
        {
            grade = 'S';
        }

        gradeText.SetText(grade.ToString());
    }

}
