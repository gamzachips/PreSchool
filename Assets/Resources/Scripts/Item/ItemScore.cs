using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScore: Item
{
    [SerializeField]
    int score = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if(collision.gameObject.CompareTag("Player"))
        {
            //점수 증가
            ScoreSystem scoreSystem = collision.gameObject.GetComponent<ScoreSystem>();
            scoreSystem.AddScore(score);

            if(score == 500)
            {
                scoreSystem.scoreItem500++;
            }
            else if (score == 1000)
            {
                scoreSystem.scoreItem1000++;
            }
            else if (score == 1500)
            {
                scoreSystem.scoreItem1500++;
            }

            //아이템 삭제
            Destroy(this.gameObject);

            audioManager.PlayItemSound();
        }
    }

}
