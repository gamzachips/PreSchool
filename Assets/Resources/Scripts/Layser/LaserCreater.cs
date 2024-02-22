using UnityEngine;

public class LaserCreator : MonoBehaviour
{
    public Vector3[] positions; // 레이저가 생성될 위치들
    private int currentIndex = 0; // 현재 위치의 인덱스
    private LineRenderer lineRenderer; // 레이저를 표현할 LineRenderer

    void Start()
    {
        // LineRenderer 컴포넌트를 가져온다 (없다면 추가한다)
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        // LineRenderer의 설정을 한다
        lineRenderer.startWidth = 0.1f; // 시작 너비
        lineRenderer.endWidth = 0.1f; // 끝 너비
        lineRenderer.positionCount = 2; // 2개의 점을 연결할 것이므로, 위치 개수를 2로 설정
    }

    void Update()
    {
        // 레이저가 생성될 두 위치를 설정
        lineRenderer.SetPosition(0, positions[currentIndex]);
        lineRenderer.SetPosition(1, positions[(currentIndex + 1) % positions.Length]);

        // 다음 위치의 인덱스를 계산 (마지막 위치에 도착하면 처음 위치로 돌아감)
        currentIndex = (currentIndex + 1) % positions.Length;
    }
}
