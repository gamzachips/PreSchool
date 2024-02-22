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
    TextMeshProUGUI rankText;

    [SerializeField]
    Button endingButton;

    ScoreSystem scoreSystem;

    void Start()
    {
        //게임아웃이면 엔딩버튼 비활성화
        scoreSystem = GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>();
        if(scoreSystem.Grade == 'F')
            endingButton.gameObject.SetActive(false);
        else
            endingButton.gameObject.SetActive(true);

        totalScore.SetText(scoreSystem.Score.ToString());
        score500.SetText(scoreSystem.scoreItem500.ToString());
        score1000.SetText(scoreSystem.scoreItem1000.ToString());
        score1500.SetText(scoreSystem.scoreItem1500.ToString());

        rankText.SetText(scoreSystem.Grade.ToString());
        
    }

}
