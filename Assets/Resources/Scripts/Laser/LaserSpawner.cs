﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
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
    GameObject laserPrefab;

    TimeChecker timeChecker;

    // 생성된 레이저를 체크하는 변수를 추가합니다.
    bool[] isLaserSpawned;

    void Start()
    {
        timeChecker = GameObject.Find("TimeChecker").GetComponent<TimeChecker>();
        // 레이저 생성 체크 변수의 배열 크기를 spawnTimings의 크기와 같게 만듭니다.
        // 처음엔 모든 레이저가 생성되지 않았으므로 false로 초기화합니다.
        isLaserSpawned = new bool[spawnTimings.Length];
    }

    void Update()
    {
        for (int i = 0; i < spawnTimings.Length; i++)
        {
            float timing = spawnTimings[i]; 
            if(Mathf.Abs(timeChecker.NowTime - timing) < Time.deltaTime)
            {
                // 이미 레이저가 생성되었다면, 더 이상 생성하지 않습니다.
                if (isLaserSpawned[i]) 
                    continue;

                GameObject laserObject = Instantiate(laserPrefab);
                Vector2 startPos = spawnPosition[i].pos[0];
                Vector2 endPos = spawnPosition[i].pos[1];
                Vector2 newPos = new Vector2((startPos.x + endPos.x) / 2, (startPos.y + endPos.y) / 2);
                float gradient = (endPos.y - startPos.y) / (endPos.x - startPos.x);
                float rotation = Mathf.Atan(gradient) * 180 / Mathf.PI;

                laserObject.transform.position = newPos;
                laserObject.transform.Rotate(new Vector3(0, 0,rotation));
                StartCoroutine(DestroyLaser(laserObject));

                isLaserSpawned[i] = true;
            }
        }
    }

    IEnumerator DestroyLaser(GameObject laser) {
        yield return new WaitForSeconds(laser.GetComponent<Laser>().PersistTime);
        Destroy(laser);
    }
}
