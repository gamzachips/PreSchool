using UnityEngine;

public class Bullet2 : MonoBehaviour {
    public Vector3[] positions;
    private int currentIndex = 0;
    public float time = 1.0f;
    private float tempTime = 0.0f;
    private float timer = 0.0f;
    private int bulletTouchCount = 0;
    private bool changedTime = false; // time 값을 변경했는지 여부를 저장하는 변수를 추가합니다.

    void Update() {
        timer += Time.deltaTime;

        transform.position = Vector3.Lerp(positions[currentIndex], positions[(currentIndex + 1) % positions.Length], timer / time);

        if (timer >= time) {
            currentIndex = (currentIndex + 1) % positions.Length;
            timer = 0.0f;
            bulletTouchCount++;

            if (bulletTouchCount == 2 && !changedTime) { // bulletTouchCount가 2가 되면 time 값을 변경합니다.
                tempTime = time;
                time = 4.0f;
                changedTime = true;
                bulletTouchCount = 0;
            }
            else if (bulletTouchCount != 2 && changedTime) { // bulletTouchCount가 3이 되면 time 값을 원래대로 돌립니다.
                time = tempTime;
                changedTime = false;
            }
        }
    }
}
