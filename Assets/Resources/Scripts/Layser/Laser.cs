using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //아이템 프리팹 종류
    [SerializeField]
    public GameObject squarePrefab;

    public Vector3[] positions; // 레이저가 생성될 위치들
    private int currentIndex = 0; // 현재 위치의 인덱스
    private LineRenderer lineRenderer; // 레이저를 표현할 LineRenderer

    void Start()
    {
/*        lineRenderer = GetComponent<LineRenderer>();

        foreach (GameObject itemPrefab in itemPrefabs)
        {
            Item itemComponent = itemPrefab.GetComponent<Item>();
            spawnTime.Add(Random.Range(itemComponent.SpawnMinTime, itemComponent.SpawnMaxTime));
        }
        // LineRenderer 컴포넌트를 가져온다 (없다면 추가한다)
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }*/
    }

    void Update()
    {
        // 레이저가 생성될 두 위치를 설정
        Vector3 start = positions[currentIndex];
        Vector3 end = positions[(currentIndex + 1) % positions.Length];

        // Square 오브젝트를 생성하고 시작 위치에 배치
        GameObject square = Instantiate(squarePrefab, start, Quaternion.identity);

        // Square 오브젝트의 크기를 시작 위치와 끝 위치 사이의 거리로 설정
        float distance = Vector3.Distance(start, end);
        square.transform.localScale = new Vector3(distance, square.transform.localScale.y, square.transform.localScale.z);

        // Square 오브젝트를 시작 위치와 끝 위치 사이의 중간점으로 이동
        square.transform.position = (start + end) / 2;

        // 다음 위치의 인덱스를 계산 (마지막 위치에 도착하면 처음 위치로 돌아감)
        currentIndex = (currentIndex + 1) % positions.Length;
    }
}
