using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpButtonManager : MonoBehaviour {
    public GameObject[] gameObject;

    void Update() {
        // 아무 방향키나 눌렀을 때
        if (Input.anyKeyDown) {
            gameObject[0].SetActive(false);
            gameObject[1].SetActive(false);
            gameObject[2].SetActive(true);
        }
    }
}