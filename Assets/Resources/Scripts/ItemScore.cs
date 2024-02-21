using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScore: Item
{
    [SerializeField]
    int score = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //점수 증가
        Destroy(this.gameObject);
    }

}
