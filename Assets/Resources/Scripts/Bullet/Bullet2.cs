using UnityEngine;

public class Bullet2 : MonoBehaviour {
    public Vector3[] positions;
    private int currentIndex = 0;
    public float time = 1.0f;
    private float tempTime = 0.0f;
    private float timer = 0.0f;
    private int bulletTouchCount = 0;
    private bool changedTime = false; // time ���� �����ߴ��� ���θ� �����ϴ� ������ �߰��մϴ�.

    void Update() {
        timer += Time.deltaTime;

        transform.position = Vector3.Lerp(positions[currentIndex], positions[(currentIndex + 1) % positions.Length], timer / time);

        if (timer >= time) {
            currentIndex = (currentIndex + 1) % positions.Length;
            timer = 0.0f;
            bulletTouchCount++;

            if (bulletTouchCount == 2 && !changedTime) { // bulletTouchCount�� 2�� �Ǹ� time ���� �����մϴ�.
                tempTime = time;
                time = 4.0f;
                changedTime = true;
                bulletTouchCount = 0;
            }
            else if (bulletTouchCount != 2 && changedTime) { // bulletTouchCount�� 3�� �Ǹ� time ���� ������� �����ϴ�.
                time = tempTime;
                changedTime = false;
            }
        }
    }
}
