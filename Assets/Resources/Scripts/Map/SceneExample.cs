using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExample : MonoBehaviour {
    public GameObject startButton; // StartButton 오브젝트를 참조하는 변수를 추가
    public GameObject endButton;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) { // 위쪽 화살표 키 누르면
            startButton.SetActive(true); // startButton 오브젝트를 활성화
            endButton.SetActive(false);
            if (Input.anyKeyDown) // 아무 키나 눌렸을 때
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) {
                    return;
                }
                else {
                    Debug.Log("Any key pressed except up and down arrow keys.");
                }
                
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) { // 아래쪽 화살표 키 누르면
            startButton.SetActive(false);
            endButton.SetActive(true); // endButton 오브젝트를 활성화
            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.UpArrow)) { // 아무 키나 눌렸을 때
                Application.Quit();
            }
        }
    }
}