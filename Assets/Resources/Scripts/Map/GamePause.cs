using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour {
    // 다른 스크립트에서 쉽게 접근이 가능하도록 static
    public static bool GameIsPaused = false;
    public GameObject pauseMenuCanvas;
    private ObjectInteract objectInteract;
    bool Interacting = false;

    private void Start() {
        objectInteract = GameObject.FindObjectOfType<ObjectInteract>();
        
    }
    void Update() {
        Interacting = objectInteract.isInteracting;
        if (!Interacting && Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause() {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}