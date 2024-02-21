using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLayer : MonoBehaviour
{

    public Vector2[] APattern;
    public Vector2[] BPattern;
    public Vector2[] CPattern;
    public Vector2[] DPattern;
    public Vector2[] GPattern;

    void Start()
    {
        APattern = new Vector2[5];
        BPattern = new Vector2[4];
        CPattern = new Vector2[3];
        DPattern = new Vector2[5];
        GPattern = new Vector2[4];
    }


    void Update()
    {
        
    }
}
