using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    //������ ������ ����
    [SerializeField]
    List<GameObject> itemPrefabs = new List<GameObject>();

    //������ ������ ����
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
        //�� �����ո���
        for(int i = 0; i < itemPrefabs.Count; i++)
        {

            //������ Ÿ���̸�
            if (Mathf.Abs(timeChecker.NowTime - spawnTime[i]) < Time.deltaTime)
            {
                //���� ������Ʈ ����
                GameObject itemObject = Instantiate(itemPrefabs[i]);

                //������ ��ǥ�� ��ġ
                float randomX = Random.Range(minX, maxX);
                float randomY = Random.Range(minY, maxY);
                itemObject.transform.position = new Vector3(randomX, randomY,0);

                //���� ���� �ð� ����
                Item itemComponent = itemPrefabs[i].GetComponent<Item>();
                spawnTime[i] += Random.Range(itemComponent.SpawnMinTime, itemComponent.SpawnMaxTime);
            }
        }
    }
}
