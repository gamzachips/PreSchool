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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.CompareTag("Player") &&
            !(playerlife.playerstate == PlayerState.defence) &&
            !(playerlife.playerstate == PlayerState.die) )
        {
            for (int i = playerlife.LifeIdx.Count() - 1; i >= 0; i--)
            {
                if (playerlife.LifeIdx[i] == false)
                {
                    playerlife.LifeIdx[i] = true;
                    Color tempColor = playerlife.Heart[i].color;
                    tempColor.a = 1f;
                    playerlife.Heart[i].color = tempColor;
                    audioManager.PlayItemSound();
                    break;
                }
            }
            //아이템 삭제
            Destroy(this.gameObject);
        }
    }


}
