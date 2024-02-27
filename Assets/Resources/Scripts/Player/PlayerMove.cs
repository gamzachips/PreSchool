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
        /*float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(h, v).normalized;


        transform.Translate(moveDir * Time.deltaTime * speed);*/
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            spriteRenderer.sprite = back;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))

        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            spriteRenderer.sprite = left;
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            spriteRenderer.sprite = left;
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            spriteRenderer.sprite = front;

        }
    }

}
