using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPersistLogic : MonoBehaviour
{
    [SerializeField]
    TimeChecker timeChecker;

    //�������� ��Ÿ���� �ð�
    [SerializeField]
    List<float> times;

    //�������� ���ӵǴ� �ð�
    [SerializeField]
    List<float> persistTime;

    //������
    [SerializeField]
    List<GameObject> lasers;

    //���� ������ �ε���
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
        //�̹� �������� ���� �ð��̸� 
        if(timeChecker.NowTime == times[nowIdx])
        {
            //������ �ѱ�
            lasers[nowIdx].SetActive(true);

            nowIdx++;
        }
    }

    public IEnumerator RemoveLaser()
    {
        yield return new WaitForSeconds(persistTime[nowIdx]);

        //������ ��Ȱ��ȭ
        lasers[nowIdx - 1].SetActive(false);
    }
}
