using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



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

    public enum PlayerState
    {
        life,
        invincible,
        die
    };

    PlayerState playerstate = PlayerState.life;

    void Start()
    {
        LifeIdx = new bool[5];
        PlayerIm = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if (playerstate == PlayerState.life)
        {
            Damagefunc();
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
                }
            }
        }

        // ��¥ �׾��°�?
        else if (LifeIdx[0] == false)
        {
            playerstate = PlayerState.die;
        }

    }

    public void OnPlayerDamage(SpriteRenderer MainPlayerIm)
    {
        IsDamage = true;
        PlayerIm = MainPlayerIm;
    }


}
