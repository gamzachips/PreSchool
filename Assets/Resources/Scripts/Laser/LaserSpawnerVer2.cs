using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner2 : MonoBehaviour
{
    [SerializeField]
    GameObject[] laserObjects;

    [Serializable]
    public class SpawnTiming
    {
        public float[] time;
        public bool[] isLaserSpawned;
    }
    public SpawnTiming[] spawnTimings;

    TimeChecker timeChecker;

    private void Start()
    {
        timeChecker = GameObject.Find("TimeChecker").GetComponent<TimeChecker>();
        
        for(int i = 0; i < spawnTimings.Length; i++)
        {
            spawnTimings[i].isLaserSpawned = new bool[spawnTimings[i].time.Length];

        }
    }

    private void Update()
    {
        for (int i = 0; i < spawnTimings.Length; i++)
        {
            for (int j = 0; j < spawnTimings[i].time.Length; j++)
            {
                float timing = spawnTimings[i].time[j];

                if (spawnTimings[i].isLaserSpawned[j]) continue;

                if (Mathf.Abs(timeChecker.NowTime - timing) < Time.deltaTime)
                {

                    laserObjects[i].SetActive(true);
                    StartCoroutine(DestroyLaser(laserObjects[i]));
                    spawnTimings[i].isLaserSpawned[j] = true;
                }
            }
        }
    }



    IEnumerator DestroyLaser(GameObject laser)
    {
        yield return new WaitForSeconds(laser.GetComponent<Laser>().PersistTime);
        laser.SetActive(false); 
    }
}