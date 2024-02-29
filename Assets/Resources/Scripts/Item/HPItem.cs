using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static PlayerLife;

public class HPItem : Item
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

        if (collision.gameObject.CompareTag("Player"))
        {
            playerlife = collision.gameObject.GetComponent<PlayerLife>();
            for (int i = 2; i >= 0; i--)
            {
                if (playerlife.LifeIdx[i] == false)
                {
                    playerlife.LifeIdx[i] = true;
                    Color tempColor = playerlife.Heart[i].color;
                    tempColor.a = 1f;
                    playerlife.Heart[i].color = tempColor;
                    AudioManager.Instance.PlayItemSound();
                    Destroy(this.gameObject);
                    break;
                }
            }
        }
    }


}
