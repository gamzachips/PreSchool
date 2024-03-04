using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour {
    // 다른 스크립트에서 쉽게 접근이 가능하도록 static
    public static bool GameIsPaused = false;
    public GameObject[] ESCManager;
    private ObjectInteract objectInteract;
    public PlayerLife playerLife;
    bool Interacting = false;

    private void Start() {
        playerLife = GameObject.FindObjectOfType<PlayerLife>();
        
    }
    void Update() {
        if (!(playerLife.playerstate == PlayerLife.PlayerState.interactive) && Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        ESCManager[0].SetActive(false);
        ESCManager[1].SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause() {
        ESCManager[0].SetActive(true);
        ESCManager[1].SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}