using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineLayer : MonoBehaviour
{

    public SpriteRenderer linelayser;


    void Start()
    {
        linelayser = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 vec = new Vector2 (0f, 0f);
        ALineLayser(vec, 0f);
    }

    public void ALineLayser(Vector2 Position, float StartTime)
    {
        linelayser = (SpriteRenderer)Resources.Load("/Scenes/Picture/CircleLayer", typeof(SpriteRenderer));

    }



}
