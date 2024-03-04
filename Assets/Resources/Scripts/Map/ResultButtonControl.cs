using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButtonControl : MonoBehaviour {
    public GameObject[] greenButton;
    private int count = 1;

    void Update() {
        // 위 방향키나 w를 눌렀을 때
        if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            greenButton[count].SetActive(false);
            if(count != 0)
                count--;
            greenButton[count].SetActive(true);
        }

        // 아래 방향키나 d를 눌렀을 때
        if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            greenButton[count].SetActive(false);
            if(0 <= count && count < 1)
                count++;
            greenButton[count].SetActive(true);
        }

        // 엔터나 z키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z)) {
            ScneManager.Instance.ChangeSceneByType(GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().sceneType);

        }
    }
}
