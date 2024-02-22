using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLayser : MonoBehaviour
{
    public GameObject layserObj;
    public float LayserCount;
    public SpriteRenderer Sprite;

    void Start()
    {

    }

    void Update()
    {
        //SelectLineLayserSprite(new Vector2(0, 0), 0, 0);
    }

    public void SelectLineLayserSprite(Vector2 Position, float StartTime, Vector2 Rotation)
    {
        layserObj.transform.position = Position;
    }
}
