using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserIndicateSpawner : MonoBehaviour {
    [SerializeField]
    GameObject[] laserIndicateObjects;

    [Serializable]
    public class SpawnTiming {
        public float[] time;
        public bool[] isLaserIndicateSpawned;
    }
    public SpawnTiming[] spawnTimings;

    TimeChecker timeChecker;

    private void Start() {
        timeChecker = GameObject.Find("TimeChecker").GetComponent<TimeChecker>();

        for (int i = 0; i < spawnTimings.Length; i++) {
            spawnTimings[i].isLaserIndicateSpawned = new bool[spawnTimings[i].time.Length];
        }
    }

    private void Update() {
        for (int i = 0; i < spawnTimings.Length; i++) {
            for (int j = 0; j < spawnTimings[i].time.Length; j++) {
                float timing = spawnTimings[i].time[j];

                if (spawnTimings[i].isLaserIndicateSpawned[j]) continue;

                // Laser가 나타나기 1초 전에 LaserIndicate가 나타나도록 timing에서 1초를 빼줍니다.
                if (Mathf.Abs(timeChecker.NowTime - (timing - 1f)) < Time.deltaTime) {
                    laserIndicateObjects[i].SetActive(true);
                    StartCoroutine(DestroyLaserIndicate(laserIndicateObjects[i]));
                    spawnTimings[i].isLaserIndicateSpawned[j] = true;
                }
            }
        }
    }

    IEnumerator DestroyLaserIndicate(GameObject laserIndicate) {
        // LaserIndicate는 Laser가 나타나기 직전에 사라져야 하므로, Laser의 PersistTime보다 1초 더 짧게 설정합니다.
        yield return new WaitForSeconds(laserIndicate.GetComponent<Laser>().PersistTime);
        laserIndicate.SetActive(false);
    }
}
