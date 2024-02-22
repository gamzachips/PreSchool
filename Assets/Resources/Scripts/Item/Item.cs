using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //���� �ֱ� �ּ�
    [SerializeField]
    protected float spawnMinTime = 0f;
    public float SpawnMinTime { get { return spawnMinTime; } }

    //���� �ֱ� �ִ�
    [SerializeField]
    protected float spawnMaxTime = 0f;
    public float SpawnMaxTime { get { return spawnMaxTime; } }

    //�Ҹ�ð�
    [SerializeField]
    protected float destroyTime = 15f;

    //�����̱� �����ϴ� �ð�
    [SerializeField]
    protected float blinkStartTime = 10f;

    //������ �ֱ�/2
    [SerializeField]
    protected float blinkIntervalTime = 0.5f;

    //������
    protected SpriteRenderer spriteRenderer;

    //������ ������ �� �ð�
    protected float nowTime = 0f;

    //�÷��̾ �Ծ����� ����
    protected bool eaten = false;

    //�����̴� ������ ����
    private bool isBlinking = false;

    Color origin = new Color(1, 1, 1, 1);
    Color transparent = new Color(1, 1, 1, 0.3f);

    //����� �Ŵ���
    protected AudioManager audioManager;
    
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>(); 
    }


    private void Update()
    {
        nowTime += Time.deltaTime;

        //������ �ð��� �Ǹ� 
        if (nowTime > blinkStartTime && !isBlinking)
        {
            StartCoroutine(Blink());
            isBlinking = true;
        }
        //�� �Ծ��� �� �Ҹ� �ð��� �Ǹ�
        else if (nowTime > destroyTime && !eaten)
        {
            //������ �Ҹ�
            Destroy(this.gameObject);
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            //������ ó�� - ����<->������
            spriteRenderer.color = (spriteRenderer.color == origin) ? transparent : origin;
            yield return new WaitForSeconds(blinkIntervalTime);
        }

    }
}
