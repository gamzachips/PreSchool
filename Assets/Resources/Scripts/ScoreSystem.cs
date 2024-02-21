using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;

    int score = 0;
    public int Score { get { return score; } }
    public void AddScore(int amount)
    {
        score += amount;
    }

    private void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        scoreText.SetText(score.ToString());
    }
}
