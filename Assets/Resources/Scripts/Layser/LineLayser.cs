using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLayser : MonoBehaviour
{
    public GameObject layserObj;
    SpriteRenderer sRender;
    public float LayserCount;
    public SpriteRenderer[] newSprite;

    void Start()
    {
        sRender = layserObj.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
    }

    public void SelectLineLayserSprite(Vector2 Position, float StartTime, Vector2 Rotation)
    {
        layserObj.transform.position = Position;
    }
}
