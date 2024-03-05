using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    static SaveManager instance;
    public static SaveManager Instance { get { Init(); return instance; } }

    static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("SaveManager");
            if (go == null)
            {
                go = new GameObject { name = "SaveManager" };
                go.AddComponent<SaveManager>();

            }
            DontDestroyOnLoad(go);
            instance = go.GetComponent<SaveManager>();
        }
    }

    private void Start()
    {
        Init();
    }

    public bool GetRankAndScore(ScneManager.SceneType type, out int rank, out int score)
    {
        if (PlayerPrefs.GetInt("Played" + type.ToString()) == 1)
        {
            rank = PlayerPrefs.GetInt("Rank" + type.ToString());
            score = PlayerPrefs.GetInt("Score" + type.ToString());
            return true;
        }
        else
        {
            rank = 0;
            score = 0;
            return false;
        }
    }

    public void SetRankAndScore(ScneManager.SceneType type, int rank, int score)
    {

        PlayerPrefs.SetInt("Played" + type.ToString(), 1);
        PlayerPrefs.SetInt("Rank" + type.ToString(), rank);
        PlayerPrefs.SetInt("Score" + type.ToString(), score);
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Played" + ScneManager.SceneType.Main.ToString(), 0);
        PlayerPrefs.SetInt("Played" + ScneManager.SceneType.Tutorial.ToString(), 0);

    }
}
