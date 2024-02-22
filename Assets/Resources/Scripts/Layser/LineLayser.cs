using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLayser : MonoBehaviour
{
    public GameObject layserObj;
    SpriteRenderer sRender;
    public float LayserCount;
    public Sprite[] newSprite;

    void Start()
    {
        sRender = layserObj.GetComponent<SpriteRenderer>();
        newSprite = new Sprite[6];
    }

    void Update()
    {
        LineLayserfunc(new Vector2(0, 0), 0, 0);
    }

    public void LineLayserfunc(Vector2 Position, float StartTime, int IndexNum)
    {
        sRender.sprite = newSprite[IndexNum];
    }
}
