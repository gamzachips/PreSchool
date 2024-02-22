using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayserSpawner : MonoBehaviour
{
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

    void Start()
    {
        timeChecker = GameObject.Find("TimeChecker").GetComponent<TimeChecker>();
    }

    void Update()
    {
        for (int i = 0; i < spawnTimings.Length; i++)
        {
            float timing = spawnTimings[i]; 
            if(Mathf.Abs(timeChecker.NowTime - timing) < Time.deltaTime)
            {
                GameObject layserObject = Instantiate(layserPrefab);
                Vector2 startPos = spawnPosition[i].pos[0];
                Vector2 endPos = spawnPosition[i].pos[1];
                Vector2 newPos = new Vector2((startPos.x + endPos.x) / 2, (startPos.y + endPos.y) / 2);
                float gradient = (endPos.y - startPos.y) / (endPos.x - startPos.x);
                float rotation = Mathf.Atan(gradient) * 180 / Mathf.PI;

                layserObject.transform.position = newPos;
                layserObject.transform.Rotate(new Vector3(0, 0,rotation));
                StartCoroutine(DestroyLayser(layserObject));
            }
        }
    }

    IEnumerator DestroyLayser(GameObject layser)
    {
        yield return new WaitForSeconds(layser.GetComponent<Layser>().PersistTime);
        Destroy(layser);
    }
}
