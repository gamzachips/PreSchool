using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScneManager : MonoBehaviour
{

    public void ChangeMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ChangeCutScene()
    {
        SceneManager.LoadScene("CutScene");
    }

    public void ChangePlayLibrary()
    {
        SceneManager.LoadScene("PlayLibraryScene");
    }

}
