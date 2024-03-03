using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour {
    public GameObject[] greenButton;
    private int count = 1;

/*    void Start() {
        for(int i = 0; i < greenButton.Length; i++) {
            greenButton[i].SetActive(false);
        }
    }*/
    void Update() {
        // 위 방향키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            greenButton[count].SetActive(false);
            if(count != 0)
                count--;
            greenButton[count].SetActive(true);
        }

        // 아래 방향키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            greenButton[count].SetActive(false);
            if(0 <= count && count < 2)
                count++;
            greenButton[count].SetActive(true);
        }

        // 위나 아래 방향키를 제외한 아무 키나 눌렸을 때
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z)) {
            // StartButton이 활성화되어 있을 때 CutScene으로 이동
            if (greenButton[0].activeSelf) {
                SceneManager.LoadScene("CutScene");
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
