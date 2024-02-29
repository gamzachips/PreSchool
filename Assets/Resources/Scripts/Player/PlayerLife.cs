using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerLife : MonoBehaviour
{
    public int MaxLife = 5;
    public int CurLife = 3;
    public SpriteRenderer PlayerIm;

    //??④봄?온??
    public float DamageTime = 0;

    //??깆뵠??
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
        die,
        interactive
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
        IsLife();


        if (!(playerstate == PlayerState.invincible) && Input.GetKeyDown(KeyCode.I))
        {
            playerstate = PlayerState.invincible;
            Debug.Log(playerstate);
        }

        Debug.Log("Chcek : " + playerstate);

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

            if (DamageTime > 3f)
            {
                playerstate = PlayerState.life;
            }
        }
        else if(playerstate == PlayerState.die)
        {
            Debug.Log("Die");
            ScoreSystem.Instance.Grade = GradeType.F;
            ScoreSystem.Instance.SaveRankAndScore(GameObject.Find("TimeChecker").GetComponent<TimeChecker>().nowStage); ;

            AudioManager.Instance.MuteMusic();
            ScneManager.Instance.ChangeResult();
        }
        else if (playerstate == PlayerState.invincible && Input.GetKeyDown(KeyCode.L))
        {
            playerstate = PlayerState.life;
        }
    }


    public void DamageEndfunc()
    {
        DamageTime = 0f;
        PlayerIm.color = PlayerOriginalColor;
        playerstate = PlayerState.life;
    }
    public void IsLife()
    {
        if (LifeIdx[4] == false)
        {
            playerstate = PlayerState.die;
        }

    }

    public void OnPlayerDamage()
    {
        if ((playerstate == PlayerState.life)
            )
        {
            for (int i = 0; i < 5; i++)
            {
                if (LifeIdx[i] == true)
                {
                    playerstate = PlayerState.damage;
                    LifeIdx[i] = false;
                    Color tempColor = Heart[i].color;
                    tempColor.a = 0f;
                    Heart[i].color = tempColor;
                    break;
                }
            }
        }

        else if (playerstate == PlayerState.defence)
        {
            playerstate = PlayerState.life;
            gameObject.GetComponentInChildren<Transform>().GetChild(0).gameObject.SetActive(false);
        }
    }


}