using UnityEngine;

public class IndicaterBullet : MonoBehaviour
{
    public Vector3[] positions; // ���� �̵��� ��ġ��
    private int currentIndex = 0; // ���� ��ġ�� �ε���
    public float time = 1.0f; // �̵� �ð�
    private float timer = 0.0f; // ��ǥ ���̸� �̵��ϴµ� �ɸ� �ð�
    private int roundCount = 0; // �� ���� ���� Ƚ��

    void Update()
    {
        // ��� �ð��� ����
        timer += Time.deltaTime;

        // ���� ���� ��ġ���� ���� ��ġ�� �ε巴�� �̵�
        transform.position = Vector3.Lerp(positions[currentIndex], positions[(currentIndex + 1) % positions.Length], timer / time);

        // ���� ���� ��ġ�� �����ߴ��� �˻�
        if (timer >= time)
        {
            // ���� ��ġ�� �ε����� ��� (������ ��ġ�� �����ϸ� ó�� ��ġ�� ���ư�)
            currentIndex = (currentIndex + 1) % positions.Length;

            // ��� �ð��� �ʱ�ȭ
            timer = 0.0f;

            // ��� ��ġ�� �� ���� ���Ҵ��� �˻�
            if (currentIndex == 0)
            {
                roundCount++; // �� ���� ���� Ƚ�� ����

                // �� ���� ���� Ƚ���� 1�� �Ǹ� ������Ʈ �ı�
                if (roundCount >= 1)
                {
                    Destroy(gameObject, 1);
                }
            }
        }
    }
}