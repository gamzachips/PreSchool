using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class PlayerLife : MonoBehaviour
{
    public int MaxLife = 5;
    public int CurLife = 3;
    public SpriteRenderer PlayerIm;

    //피격관련
    public float DamageTime = 0;

    //라이프
    [SerializeField]
    public bool[] LifeIdx;
    public Image[] Heart;
    public GameObject Player;
    public GameObject bullet;
    public Color PlayerOriginalColor;


    public enum PlayerState
    {
        life,
        invincible,
        damage,
        defence,
        die
    };

    public PlayerState playerstate = PlayerState.life;

    void Start()
    {
        LifeIdx = new bool[5];
        PlayerIm = GetComponent<SpriteRenderer>();
        PlayerOriginalColor = PlayerIm.color;

        for (int i = 0; i < 5; i++)
        {
            LifeIdx[i] = true;
        }
    }


    private void Update()
    {

        if (playerstate == PlayerState.life)
        {
            DamageEndfunc();
        }

        else if (playerstate == PlayerState.defence)
        {
            
        }

        else if (playerstate == PlayerState.damage)
        {
            DamageTime += Time.deltaTime;

            Color tempColor = PlayerIm.color;
            tempColor.a = 0.85f;
            tempColor.r = 1f;
            tempColor.g = 0.2f;
            tempColor.b = 0.2f;
            PlayerIm.color = tempColor;

            if(DamageTime > 3f)
            {
                DamageEndfunc();
            }
        }
    }


    public void DamageEndfunc()
    {
        playerstate = PlayerState.life;
        DamageTime = 0f;
        PlayerIm.color = PlayerOriginalColor;
 
    }
    public void IsLife()
    {
        // 살아있는가?
        if(CurLife != 0)
        {
            for (int i = 0; i < MaxLife; i++)
            {
                if (LifeIdx[i] == true)
                {
                    playerstate = PlayerState.life;
                    break;
                }
            }
        }

        // 진짜 죽었는가?
        else if (LifeIdx[0] == false)
        {
            playerstate = PlayerState.die;
        }

    }

    public void OnPlayerDamage()
    {
        if (!(playerstate == PlayerState.defence) &&
            !(playerstate == PlayerState.die)
            )
        {

            for (int i = 0; i < 5; i++)
            {
                if (LifeIdx[i] == true)
                {
                    LifeIdx[i] = false;
                    Color tempColor = Heart[i].color;
                    tempColor.a = 0f;
                    Heart[i].color = tempColor;
                    playerstate = PlayerState.damage;
                    break;
                }
            }
        }

        else if (playerstate == PlayerState.defence)
        {
            playerstate = PlayerState.life;

            // 이미지 넣어주기
        }
    }


}
