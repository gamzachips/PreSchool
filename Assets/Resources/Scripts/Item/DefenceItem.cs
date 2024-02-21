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

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.name == "Player"
            && (playerlife.playerstate == PlayerLife.PlayerState.life) )
        {
            playerlife.playerstate = PlayerState.defence;
            audioManager.PlayItemSound();
            //아이템 삭제
            Destroy(this.gameObject);
        }
    }
}

