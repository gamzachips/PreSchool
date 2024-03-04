using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCButtonControl : MonoBehaviour {
    public GameObject[] greenButton;
    private int count = 1;
    private GamePause gamePause;

    void Start () {
        count = 0;
        gamePause = GameObject.FindObjectOfType<GamePause>();
    }

    void Update() {
        // 위 방향키를 눌렀을 때
        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            greenButton[count].SetActive(false);
            if(count != 0)
                count--;
            greenButton[count].SetActive(true);
        }

        // 아래 방향키를 눌렀을 때
        if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            greenButton[count].SetActive(false);
            if(0 <= count && count < 1)
                count++;
            greenButton[count].SetActive(true);
        }

        // 위나 아래 방향키를 제외한 아무 키나 눌렸을 때
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z)) {
            // 돌아가기 버튼이 활성화되어 있을 때
            if (greenButton[0].activeSelf) {
                count = 0;
                gamePause.Resume();
            }

            // EndButton이 활성화되어 있을 때 게임 종료
            if (greenButton[1].activeSelf) {
                count = 0;
                gamePause.Resume();
                SceneManager.LoadScene("MenuScene");
            }
        }
    }
}
