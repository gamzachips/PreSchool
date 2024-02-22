using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionTest : MonoBehaviour
{
    public GameObject layserObj;
    SpriteRenderer sRender;
    public float LayserCount;
    public Sprite[] newSprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerLife>().OnPlayerDamage();
        }
    }
}

