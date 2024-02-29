using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScneManager : MonoBehaviour
{
    public enum SceneType
    {
        None, Menu, Main, StartCutScene, EndingCutScene, Room, Result, Tutorial
    }


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
    }

    public void ChangeRoom()
    {
        SceneManager.LoadScene("GranpaRoom");
        AudioManager.Instance.MuteMusic();
    }

    public void ChangeTutorial()
    {
        ScoreSystem.Instance.Reset();
        SceneManager.LoadScene("Tutorial");
    }

    public void ChangeSceneByType(SceneType type)
    {
        switch(type) 
        {
            case SceneType.None:
                break;
            case SceneType.Menu:
                ChangeMenu();
                break;
            case SceneType.Main:
                ChangeMain();
                break;
            case SceneType.StartCutScene:
                ChangeCutScene();
                break;
            case SceneType.EndingCutScene:
                ChangeEnding();
                break;
            case SceneType.Result:
                ChangeResult();
                break;
            case SceneType.Room:
                ChangeRoom();
                break;
            case SceneType.Tutorial:
                ChangeTutorial();
                break;
        }
    }
}
