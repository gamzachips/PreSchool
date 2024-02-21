using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    protected float destroyTime = 15f;

    [SerializeField]
    protected float blinkStartTime = 10f;

    [SerializeField]
    protected float blinkIntervalTime = 0.5f;

    protected SpriteRenderer renderer;

    protected float nowTime = 0f;
    protected bool eaten = false;
    private bool isBlinking = false;

    Color origin = new Color(1, 1, 1, 1);
    Color transparent = new Color(1, 1, 1, 0);

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        nowTime += Time.deltaTime;
        
        //������ �ð��� �Ǹ� 
        if(nowTime > blinkStartTime && !isBlinking)
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
        while(true)
        {
            renderer.color = (renderer.color == origin) ? transparent : origin;
            yield return new WaitForSeconds(blinkIntervalTime);
        }
        
    }
}
