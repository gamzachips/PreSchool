using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UIElements;

public class LineLayer : MonoBehaviour
{

    public GameObject layserObj;
    SpriteRenderer sRender;
    public float LayserCount;
    public Sprite[] newSpritep;

    void Start()
    {
        sRender = layserObj.GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        ALineLayser(new Vector2(0, 0), 0);
    }

    public void ALineLayser(Vector2 Position, float StartTime)
    {
        //sRender.sprite = newSprite;
    }



}
