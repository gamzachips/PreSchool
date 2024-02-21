using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    float spawnTimeMin = 0f;
    public float SpawnTimeMin {  get { return spawnTimeMin; }  }

    [SerializeField]
    float spawnTimeMax = 0f;
    public float SpawnTimeMax { get { return spawnTimeMax; } }

    [SerializeField]
    float destroyTime = 15f;

    [SerializeField]
    float blinkStartTime = 10f;

    [SerializeField]
    float blinkIntervalTime = 0.5f;

    private SpriteRenderer renderer;

    private float nowTime = 0f;
    private float spawnTime = 0f;

    Color origin = new Color(1, 1, 1, 1);
    Color transparent = new Color(1, 1, 1, 0);

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
    }

    private void Update()
    {
        nowTime += Time.deltaTime;
        
        //±Ù∫˝¿” Ω√∞£¿Ã µ«∏È 
        if(nowTime > blinkIntervalTime)
        {
            StartCoroutine(Blink());
        }
        //º“∏Í Ω√∞£¿Ã µ«∏È
        else if (nowTime > spawnTime)
        {
            //æ∆¿Ã≈€ º“∏Í
            Destroy(this);
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
