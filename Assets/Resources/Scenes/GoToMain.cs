using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMain : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {

        
    }

    public void Change()
    {
        SceneManager.LoadScene("MainScene");
    }
}
