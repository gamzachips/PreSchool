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

    //�ǰݰ���
    public bool IsDamage = false;
    public float DamageTime = 0;

    //������
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
        // ����ִ°�?
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

        // ��¥ �׾��°�?
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
