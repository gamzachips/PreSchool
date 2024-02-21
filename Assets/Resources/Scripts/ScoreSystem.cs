using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    int score = 0;
    public int Score { get { return score; } }
    public void AddScore(int amount)
    {
        score += amount;
    }
}
