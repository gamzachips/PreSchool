using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //������ ������ ����
    [SerializeField]
    public GameObject squarePrefab;

    public Vector3[] positions; // �������� ������ ��ġ��
    private int currentIndex = 0; // ���� ��ġ�� �ε���
    private LineRenderer lineRenderer; // �������� ǥ���� LineRenderer

    void Start()
    {
/*        lineRenderer = GetComponent<LineRenderer>();

        foreach (GameObject itemPrefab in itemPrefabs)
        {
            Item itemComponent = itemPrefab.GetComponent<Item>();
            spawnTime.Add(Random.Range(itemComponent.SpawnMinTime, itemComponent.SpawnMaxTime));
        }
        // LineRenderer ������Ʈ�� �����´� (���ٸ� �߰��Ѵ�)
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }*/
    }

    void Update()
    {
        // �������� ������ �� ��ġ�� ����
        Vector3 start = positions[currentIndex];
        Vector3 end = positions[(currentIndex + 1) % positions.Length];

        // Square ������Ʈ�� �����ϰ� ���� ��ġ�� ��ġ
        GameObject square = Instantiate(squarePrefab, start, Quaternion.identity);

        // Square ������Ʈ�� ũ�⸦ ���� ��ġ�� �� ��ġ ������ �Ÿ��� ����
        float distance = Vector3.Distance(start, end);
        square.transform.localScale = new Vector3(distance, square.transform.localScale.y, square.transform.localScale.z);

        // Square ������Ʈ�� ���� ��ġ�� �� ��ġ ������ �߰������� �̵�
        square.transform.position = (start + end) / 2;

        // ���� ��ġ�� �ε����� ��� (������ ��ġ�� �����ϸ� ó�� ��ġ�� ���ư�)
        currentIndex = (currentIndex + 1) % positions.Length;
    }
}
