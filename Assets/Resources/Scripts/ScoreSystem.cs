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

    char grade = 'C';
    public char Grade { get { return grade; } }
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
        DontDestroyOnLoad(this.gameObject);
    }
    public void Update()
    {
        if(gradeText != null)
            gradeText.SetText(grade.ToString());
    }
    
    private void SetGrade()
    {
        if (score < 4950)
        {
            grade = 'C';
        }
        else if (score < 13200)
        {
            grade = 'B';
        }
        else if (score < 21450)
        {
            grade = 'A';
        }
        else
        {
            grade = 'S';
        }

        PlayerLife playerLife = GameObject.Find("Player").GetComponent<PlayerLife>();
        if(playerLife!= null)
        {
            if(playerLife.playerstate == PlayerLife.PlayerState.die)
            {
                grade = 'F';
            }
        }
    }
}
