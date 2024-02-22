using UnityEngine;

public class Bullet3 : MonoBehaviour {
    public Vector3[] positions; // ���� �̵��� ��ġ��
    private int currentIndex = 0; // ���� ��ġ�� �ε���
    public float time = 1.0f; // �̵� �ð�
    private float timer = 0.0f; // ��� �ð�

    void Update() {
        // ��� �ð��� ����
        timer += Time.deltaTime;

        // ���� ���� ��ġ���� ���� ��ġ�� �ε巴�� �̵�
        transform.position = Vector3.Lerp(positions[currentIndex], positions[(currentIndex + 1) % positions.Length], timer / time);

        // ���� ���� ��ġ�� �����ߴ��� �˻�
        if (timer >= time) {
            // ���� ��ġ�� �ε����� ��� (������ ��ġ�� �����ϸ� ó�� ��ġ�� ���ư�)
            currentIndex = (currentIndex + 1) % positions.Length;

            // ��� �ð��� �ʱ�ȭ
            timer = 0.0f;
        }
    }

    void OnCollisionEnter(Collision collision) {
        // ���� ���� �ε������� �˻�
        if (collision.gameObject.tag == "Wall") {
            // ���� ��ġ�� �ε����� ��� (������ ��ġ�� �����ϸ� ó�� ��ġ�� ���ư�)
            currentIndex = (currentIndex + 1) % positions.Length;

            // ��� �ð��� �ʱ�ȭ
            timer = 0.0f;
        }
    }
}
