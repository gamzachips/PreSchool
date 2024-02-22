using UnityEngine;

public class LaserCreator : MonoBehaviour
{
    public Vector3[] positions; // �������� ������ ��ġ��
    private int currentIndex = 0; // ���� ��ġ�� �ε���
    private LineRenderer lineRenderer; // �������� ǥ���� LineRenderer

    void Start()
    {
        // LineRenderer ������Ʈ�� �����´� (���ٸ� �߰��Ѵ�)
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        // LineRenderer�� ������ �Ѵ�
        lineRenderer.startWidth = 0.1f; // ���� �ʺ�
        lineRenderer.endWidth = 0.1f; // �� �ʺ�
        lineRenderer.positionCount = 2; // 2���� ���� ������ ���̹Ƿ�, ��ġ ������ 2�� ����
    }

    void Update()
    {
        // �������� ������ �� ��ġ�� ����
        lineRenderer.SetPosition(0, positions[currentIndex]);
        lineRenderer.SetPosition(1, positions[(currentIndex + 1) % positions.Length]);

        // ���� ��ġ�� �ε����� ��� (������ ��ġ�� �����ϸ� ó�� ��ġ�� ���ư�)
        currentIndex = (currentIndex + 1) % positions.Length;
    }
}
