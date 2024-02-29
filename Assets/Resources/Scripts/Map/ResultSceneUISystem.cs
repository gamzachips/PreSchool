using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneUISystem : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI totalScore;
    [SerializeField]
    TextMeshProUGUI score500;
    [SerializeField]
    TextMeshProUGUI score1000;
    [SerializeField]
    TextMeshProUGUI score1500;

    [SerializeField]
    Image rankImage;

    [SerializeField]
    TextMeshProUGUI rankOrGameover;

    ScoreSystem scoreSystem;

    [SerializeField]
    Sprite[] gradeSprites;

    void Start()
    {
        AudioManager.Instance.MuteMusic();

        scoreSystem = GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>();
        if(scoreSystem.Grade == GradeType.F)
        {
            rankOrGameover.SetText("Game Over...");
        }
        else
        {
            rankOrGameover.SetText("Rank");
        }

        totalScore.SetText(scoreSystem.Score.ToString());
        score500.SetText(scoreSystem.scoreItem500.ToString());
        score1000.SetText(scoreSystem.scoreItem1000.ToString());
        score1500.SetText(scoreSystem.scoreItem1500.ToString());

        rankImage.sprite = gradeSprites[(int)scoreSystem.Grade];

    }

}
