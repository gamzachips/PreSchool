using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayserSpawner : MonoBehaviour
{
    public int repeat;

    [Serializable]
    public class SpawnPosition
    {
        public Vector2[] pos;
    }
    public SpawnPosition[] spawnPosition;

    [SerializeField]
    float[] spawnTimings;

    [SerializeField]
    GameObject layserPrefab;

    TimeChecker timeChecker;

    // ������ �������� üũ�ϴ� ������ �߰��մϴ�.
    bool[] isLayserSpawned;

    void Start()
    {
        timeChecker = GameObject.Find("TimeChecker").GetComponent<TimeChecker>();
        // ������ ���� üũ ������ �迭 ũ�⸦ spawnTimings�� ũ��� ���� ����ϴ�.
        // ó���� ��� �������� �������� �ʾ����Ƿ� false�� �ʱ�ȭ�մϴ�.
        isLayserSpawned = new bool[spawnTimings.Length];
    }

    void Update()
    {
        for (int i = 0; i < spawnTimings.Length; i++)
        {
            float timing = spawnTimings[i]; 
            if(Mathf.Abs(timeChecker.NowTime - timing) < Time.deltaTime)
            {
                // �̹� �������� �����Ǿ��ٸ�, �� �̻� �������� �ʽ��ϴ�.
                if (isLayserSpawned[i]) 
                    continue;

                GameObject layserObject = Instantiate(layserPrefab);
                Vector2 startPos = spawnPosition[i].pos[0];
                Vector2 endPos = spawnPosition[i].pos[1];
                Vector2 newPos = new Vector2((startPos.x + endPos.x) / 2, (startPos.y + endPos.y) / 2);
                float gradient = (endPos.y - startPos.y) / (endPos.x - startPos.x);
                float rotation = Mathf.Atan(gradient) * 180 / Mathf.PI;

                layserObject.transform.position = newPos;
                layserObject.transform.Rotate(new Vector3(0, 0,rotation));
                StartCoroutine(DestroyLayser(layserObject));

                isLayserSpawned[i] = true;
            }
        }
    }

    IEnumerator DestroyLayser(GameObject layser) {
        Debug.Log("DestroyLayser started"); // �ڷ�ƾ ���� �α�
        yield return new WaitForSeconds(layser.GetComponent<Layser>().PersistTime);
        Debug.Log("DestroyLayser ended"); // �ڷ�ƾ ���� �α�
        Destroy(layser);
    }
}
