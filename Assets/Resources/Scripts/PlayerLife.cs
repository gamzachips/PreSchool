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
    public bool IsDamage = false;
    public float DamageTime = 0;

    //라이프
    [SerializeField]
    bool[] LifeIdx;
    public Image[] Heart;
    public GameObject Player;
    public GameObject bullet;


    public enum PlayerState
    {
        life,
        invincible,
        die,
        defence
    };

    PlayerState playerstate = PlayerState.life;

    void Start()
    {
        LifeIdx = new bool[5];
        PlayerIm = GetComponent<SpriteRenderer>();

        for (int i = 0; i < 5; i++)
        {
            LifeIdx[i] = true;
        }
    }


    private void Update()
    {
        if (playerstate == PlayerState.life)
        {

        }
    }


    public void Damagefunc()
    {
        if (IsDamage)
        {
            DamageTime += Time.deltaTime;

            PlayerIm.enabled = false;
        }

        if (DamageTime >= 3f)
        {
            IsDamage = false;
            PlayerIm.enabled = true;
        }
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
        IsDamage = true;

        for (int i = 0; i < 5; i++)
        {
            if (LifeIdx[i] == true)
            {
                LifeIdx[i] = false;
                Color tempColor = Heart[i].color;
                tempColor.a = 0f;
                Heart[i].color = tempColor;
                break;
            }
        }
    }


}
