using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float speed = 100f;

    [SerializeField]
    Sprite front;

    [SerializeField]
    Sprite back;

    [SerializeField]
    Sprite left;


    public float Speed {  get { return speed; } set {  speed = value; } }

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movedir = new Vector3(h, v, 0).normalized;

        if (gameObject.GetComponent<PlayerLife>().playerstate == PlayerLife.PlayerState.interactive)
            return;

        transform.Translate(movedir * Time.fixedDeltaTime * speed);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            spriteRenderer.sprite = back;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.sprite = left;
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.sprite = left;
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = front;
        }
    }

}
