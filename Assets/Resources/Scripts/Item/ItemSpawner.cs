using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    //아이템 프리팹 종류
    [SerializeField]
    List<GameObject> itemPrefabs = new List<GameObject>();

    //아이템 스폰할 범위
    [SerializeField]
    float minX = 0;
    [SerializeField]
    float maxX = 0;
    [SerializeField]
    float minY = 0;
    [SerializeField]
    float maxY = 0;

    TimeChecker timeChecker;

    List<float> spawnTime = new List<float>();

    void Start()
    {
        timeChecker = GameObject.Find("TimeChecker").GetComponent<TimeChecker>();

        foreach(GameObject itemPrefab in itemPrefabs)
        {
            Item itemComponent = itemPrefab.GetComponent<Item>();
            spawnTime.Add(Random.Range(itemComponent.SpawnMinTime, itemComponent.SpawnMaxTime));
        }
    }

    void Update()
    {
        //각 프리팹마다
        for(int i = 0; i < itemPrefabs.Count; i++)
        {

            //스폰할 타임이면
            if (Mathf.Abs(timeChecker.NowTime - spawnTime[i]) < Time.deltaTime)
            {
                //게임 오브젝트 생성
                GameObject itemObject = Instantiate(itemPrefabs[i]);

                //랜덤한 좌표에 위치
                float randomX = Random.Range(minX, maxX);
                float randomY = Random.Range(minY, maxY);
                itemObject.transform.position = new Vector3(randomX, randomY,0);

                //다음 스폰 시간 설정
                Item itemComponent = itemPrefabs[i].GetComponent<Item>();
                spawnTime[i] += Random.Range(itemComponent.SpawnMinTime, itemComponent.SpawnMaxTime);
            }
        }
    }
}
