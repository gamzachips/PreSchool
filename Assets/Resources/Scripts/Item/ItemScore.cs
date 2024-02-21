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
            //���� ����
            collision.gameObject.GetComponent<ScoreSystem>().AddScore(score);

            //������ ����
            Destroy(this.gameObject);
        }
    }

}
