using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayserManager : MonoBehaviour
{
    public Vector2[] APattern;
    public Vector2[] BPattern;
    public Vector2[] CPattern;
    public Vector2[] DPattern;
    public Vector2[] FPattern;
    public Vector2[] GPattern;

    public enum LineLayserPattern
    {
        APattern,
        BPattern,
        CPattern,
        DPattern,
        FPattern,
        GPattern
    };

    void Start()
    {

        APattern = new Vector2[5];
        BPattern = new Vector2[4];
        CPattern = new Vector2[3];
        DPattern = new Vector2[5];
        FPattern = new Vector2[4];
        GPattern = new Vector2[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
