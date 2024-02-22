using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public GameObject objectPrefab; // ������ ������Ʈ�� ������
    public Vector2 spawnPosition1; // ���� ��ġ 1
    public Vector2 spawnPosition2; // ���� ��ġ 2
    public float spawnTime; // ���� �ð�

    IEnumerator Start() {
        yield return new WaitForSeconds(spawnTime); // ���� �ð���ŭ ���

        // ������Ʈ�� ���� ��ġ 1�� ����
        Instantiate(objectPrefab, spawnPosition1, Quaternion.identity);

        yield return new WaitForSeconds(spawnTime); // ���� �ð���ŭ ���

        // ������Ʈ�� ���� ��ġ 2�� ����
        Instantiate(objectPrefab, spawnPosition2, Quaternion.identity);
    }
}
