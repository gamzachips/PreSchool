using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonControl : MonoBehaviour {
    public GameObject[] greenButton;
    private int count = 1;

    void Update() {
        // 위 방향키나 w를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            greenButton[count].SetActive(false);
            if(count != 0)
                count--;
            greenButton[count].SetActive(true);
        }

        // 아래 방향키나 d를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            greenButton[count].SetActive(false);
            if(0 <= count && count < 2)
                count++;
            greenButton[count].SetActive(true);
        }

        // 엔터나 z키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z)) {
            // StartButton이 활성화되어 있을 때 CutScene으로 이동
            if (greenButton[0].activeSelf) {
                SceneManager.LoadScene("CutScene");
            }

            if (greenButton[1].activeSelf) {
                SceneManager.LoadScene("GranpaRoom");
            }

            // EndButton이 활성화되어 있을 때 게임 종료
            if (greenButton[2].activeSelf) {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
        }
    }
}
