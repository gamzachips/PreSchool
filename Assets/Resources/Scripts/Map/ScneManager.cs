using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScneManager : MonoBehaviour
{

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
