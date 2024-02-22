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
        //SelectLineLayserSprite(new Vector2(0, 0), 0, 0);
    }

    public void SelectLineLayserSprite(Vector2 Position, float StartTime, int IndexNum, Vector2 Rotation)
    {
        sRender.sprite = newSprite[IndexNum];
        layserObj.transform.position = Position;
    }
}
