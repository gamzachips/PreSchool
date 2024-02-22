using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float speed = 100f;

    public float Speed {  get { return speed; } set {  speed = value; } }

 
    void Update()
    {
        /*float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(h, v).normalized;


        transform.Translate(moveDir * Time.deltaTime * speed);*/
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))

        {

            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))

        {

            transform.Translate(Vector3.right * Time.deltaTime * speed);

        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))

        {

            transform.Translate(Vector3.down * Time.deltaTime * speed);

        }
    }

}
