using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPersistLogic : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1f;

    [SerializeField]
    TimeChecker timeChecker;

    //레이저가 나타나는 시간
    [SerializeField]
    List<float> times;

    //레이저가 지속되는 시간
    [SerializeField]
    List<float> persistTime;

    //레이저
    [SerializeField]
    List<GameObject> lasers;

    //현재 레이저 인덱스
    int nowIdx = 0;

    private void Start()
    {
        timeChecker = GameObject.Find("TimeChecker").GetComponent<TimeChecker>();

        foreach(GameObject laser in lasers)
        {
            laser.SetActive(false);
        }
    }

    private void Update()
    {
        //이번 레이저가 나올 시간이면 
        if(Mathf.Abs(timeChecker.NowTime -times[nowIdx]) < Time.deltaTime )
        {
            //레이저 켜기
            lasers[nowIdx].SetActive(true);

            nowIdx++;
        }
    }

    public IEnumerator RemoveLaser()
    {
        yield return new WaitForSeconds(persistTime[nowIdx]);

        //레이저 비활성화
        lasers[nowIdx - 1].SetActive(false);
    }
}
