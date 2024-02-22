using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public GameObject objectPrefab; // 생성할 오브젝트의 프리팹
    public Vector2 spawnPosition1; // 생성 위치 1
    public Vector2 spawnPosition2; // 생성 위치 2
    public float spawnTime; // 생성 시간

    IEnumerator Start() {
        yield return new WaitForSeconds(spawnTime); // 생성 시간만큼 대기

        // 오브젝트를 생성 위치 1에 생성
        Instantiate(objectPrefab, spawnPosition1, Quaternion.identity);

        yield return new WaitForSeconds(spawnTime); // 생성 시간만큼 대기

        // 오브젝트를 생성 위치 2에 생성
        Instantiate(objectPrefab, spawnPosition2, Quaternion.identity);
    }
}
