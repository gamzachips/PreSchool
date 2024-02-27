using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static PlayerLife;

public class DefenceItem : Item
{
    public PlayerLife playerlife;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        playerlife = collision.gameObject.GetComponent<PlayerLife>();
        if (collision.gameObject.CompareTag("Player")
            && (playerlife.playerstate != PlayerLife.PlayerState.defence) )
        {
            playerlife.playerstate = PlayerState.defence;
            AudioManager.Instance.PlayItemSound();
            collision.gameObject.GetComponentInChildren<Transform>().GetChild(0).gameObject.SetActive(true);
            //아이템 삭제
            Destroy(this.gameObject);
        }
    }
}

