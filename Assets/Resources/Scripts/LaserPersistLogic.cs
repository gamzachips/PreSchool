using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPersistLogic : MonoBehaviour
{
    [SerializeField]
    TimeChecker timeChecker;

    [SerializeField]
    float indicatorTime = 1f;

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
        //레이저가 나오기 이전 시간에
        if(Mathf.Abs(timeChecker.NowTime - times[nowIdx]) - indicatorTime < Time.deltaTime)
        {
            //레이저 켜기
            lasers[nowIdx].SetActive(true);
            //충돌 비활성화
            lasers[nowIdx].GetComponent<BoxCollider2D>().enabled = false;
            //알파값 낮춤
            lasers[nowIdx].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
        }

        //이번 레이저가 나올 시간이면 
        if(Mathf.Abs(timeChecker.NowTime -times[nowIdx]) < Time.deltaTime )
        {
            //충돌 활성화
            lasers[nowIdx].GetComponent<BoxCollider2D>().enabled = true;
            //색상 원래대로
            lasers[nowIdx].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);

            StartCoroutine(RemoveLaser());
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
