using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScneManager : MonoBehaviour
{
    //싱글톤
    static ScneManager instance;
    public static ScneManager Instance { get { Init(); return instance; } }

    static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("ScneManager");
            if (go == null)
            {
                go = new GameObject { name = "ScneManager" };
                go.AddComponent<ScneManager>();
            }
            DontDestroyOnLoad(go);
            instance = go.GetComponent<ScneManager>();
        }
    }

    private void Start()
    {
        Init();
    }

    public void ChangeMain()
    {
        SceneManager.LoadScene("RoopAI");
         ScoreSystem.Instance.Reset();
         AudioManager.Instance.PlayGameMusic();
    }

    public void ChangeCutScene()
    {
        SceneManager.LoadScene("CutScene");
    }

    public void ChangePlayLibrary()
    {
        SceneManager.LoadScene("PlayLibraryScene");
    }

    public void ChangeMenu()
    {
        SceneManager.LoadScene("MenuScene");
        AudioManager.Instance.PlayMainMusic();
    }
    public void ChangeEnding()
    {
        SceneManager.LoadScene("EndingScene");
    }
    public void ChangeResult()
    {
        SceneManager.LoadScene("ResultScene");
        AudioManager.Instance.MuteMusic();
    }
}
