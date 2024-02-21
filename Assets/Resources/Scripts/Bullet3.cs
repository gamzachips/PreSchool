using UnityEngine;

public class Bullet3 : MonoBehaviour {
    public Vector3[] positions; // 공이 이동할 위치들
    private int currentIndex = 0; // 현재 위치의 인덱스
    public float time = 1.0f; // 이동 시간
    private float timer = 0.0f; // 경과 시간

    void Update() {
        // 경과 시간을 누적
        timer += Time.deltaTime;

        // 공이 현재 위치에서 다음 위치로 부드럽게 이동
        transform.position = Vector3.Lerp(positions[currentIndex], positions[(currentIndex + 1) % positions.Length], timer / time);

        // 공이 다음 위치에 도착했는지 검사
        if (timer >= time) {
            // 다음 위치의 인덱스를 계산 (마지막 위치에 도착하면 처음 위치로 돌아감)
            currentIndex = (currentIndex + 1) % positions.Length;

            // 경과 시간을 초기화
            timer = 0.0f;
        }
    }

    void OnCollisionEnter(Collision collision) {
        // 공이 벽에 부딪혔는지 검사
        if (collision.gameObject.tag == "Wall") {
            // 다음 위치의 인덱스를 계산 (마지막 위치에 도착하면 처음 위치로 돌아감)
            currentIndex = (currentIndex + 1) % positions.Length;

            // 경과 시간을 초기화
            timer = 0.0f;
        }
    }
}
