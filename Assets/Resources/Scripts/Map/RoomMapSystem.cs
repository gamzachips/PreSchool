using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMapSystem : MonoBehaviour
{
    [SerializeField]
    GameObject computerCollider;

    [SerializeField]
    GameObject computerMusicAnimation;

    private void Start()
    {
        int rank;
        int score;
        if(SaveManager.Instance.GetRankAndScore(ScneManager.SceneType.Tutorial, out rank, out score))
        {
            if (rank != (int)GradeType.F)
            {
                computerMusicAnimation.SetActive(true);
                computerCollider.SetActive(true);
            }
            else
            {
                computerMusicAnimation.SetActive(false);
                computerCollider.SetActive(false);
            }
        }
        else
        {
            computerMusicAnimation.SetActive(false);
            computerCollider.SetActive(false);
        }
    }

}
