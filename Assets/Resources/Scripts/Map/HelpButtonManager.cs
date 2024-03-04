using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpButtonManager : MonoBehaviour {
    public GameObject[] gameObjects;

    void Update() {
        // 아무 방향키나 눌렀을 때

        if (Input.anyKeyDown || PlayerPrefs.GetInt("Played" + ScneManager.SceneType.Tutorial.ToString()) == 1)

        {
            gameObjects[0].SetActive(false);
            gameObjects[1].SetActive(false);
        }
    }
}