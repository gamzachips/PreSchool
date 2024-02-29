using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexibleCollisonTest : BulletCollisionTest
{
    SpriteRenderer sRender;
    BoxCollider2D boxCollider;

    Vector2 initialColliderSize;

    [SerializeField]
    bool xyRotate = false;

    // Start is called before the first frame update
    void Start()
    {
        sRender = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        initialColliderSize = boxCollider.size;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentSpriteSize = sRender.bounds.size;

        if (currentSpriteSize != initialColliderSize)
        {
            if(xyRotate)
            {
                boxCollider.size = new Vector2(25, currentSpriteSize.x);
                initialColliderSize = new Vector2(25, currentSpriteSize.x);
            }
            else
            {
                boxCollider.size = new Vector2(25,currentSpriteSize.y );
                initialColliderSize = new Vector2(25, currentSpriteSize.y );
            }
        }
    }
}
