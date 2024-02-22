using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //생성 주기 최소
    [SerializeField]
    protected float spawnMinTime = 0f;
    public float SpawnMinTime { get { return spawnMinTime; } }

    //생성 주기 최대
    [SerializeField]
    protected float spawnMaxTime = 0f;
    public float SpawnMaxTime { get { return spawnMaxTime; } }

    //소멸시간
    [SerializeField]
    protected float destroyTime = 15f;

    //깜빡이기 시작하는 시간
    [SerializeField]
    protected float blinkStartTime = 10f;

    //깜빡임 주기/2
    [SerializeField]
    protected float blinkIntervalTime = 0.5f;

    //렌더러
    protected SpriteRenderer spriteRenderer;

    //아이템 생성된 후 시간
    protected float nowTime = 0f;

    //플레이어가 먹었는지 여부
    protected bool eaten = false;

    //깜빡이는 중인지 여부
    private bool isBlinking = false;

    Color origin = new Color(1, 1, 1, 1);
    Color transparent = new Color(1, 1, 1, 0.3f);

    //오디오 매니저
    protected AudioManager audioManager;
    
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>(); 
    }


    private void Update()
    {
        nowTime += Time.deltaTime;

        //깜빡임 시간이 되면 
        if (nowTime > blinkStartTime && !isBlinking)
        {
            StartCoroutine(Blink());
            isBlinking = true;
        }
        //안 먹었을 때 소멸 시간이 되면
        else if (nowTime > destroyTime && !eaten)
        {
            //아이템 소멸
            Destroy(this.gameObject);
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            //깜빡임 처리 - 투명<->불투명
            spriteRenderer.color = (spriteRenderer.color == origin) ? transparent : origin;
            yield return new WaitForSeconds(blinkIntervalTime);
        }

    }
}
