using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {
    public GameObject bullet; // 활성화할 오브젝트
    public float delayTime; // 기다릴 시간

    void Start() {
        StartCoroutine(ActivateAfterDelay());
    }

    IEnumerator ActivateAfterDelay() {
        yield return new WaitForSeconds(delayTime); // 지정한 시간만큼 대기
        bullet.SetActive(true); // 오브젝트 활성화
    }
}