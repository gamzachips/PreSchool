using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPersistLogic : MonoBehaviour
{
    [SerializeField]
    TimeChecker timeChecker;

    [SerializeField]
    float indicatorTime = 1f;

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
        //�������� ������ ���� �ð���
        if(Mathf.Abs(timeChecker.NowTime - times[nowIdx]) - indicatorTime < Time.deltaTime)
        {
            //������ �ѱ�
            lasers[nowIdx].SetActive(true);
            //�浹 ��Ȱ��ȭ
            lasers[nowIdx].GetComponent<BoxCollider2D>().enabled = false;
            //���İ� ����
            lasers[nowIdx].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
        }

        //�̹� �������� ���� �ð��̸� 
        if(Mathf.Abs(timeChecker.NowTime -times[nowIdx]) < Time.deltaTime )
        {
            //�浹 Ȱ��ȭ
            lasers[nowIdx].GetComponent<BoxCollider2D>().enabled = true;
            //���� �������
            lasers[nowIdx].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);

            StartCoroutine(RemoveLaser());
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
