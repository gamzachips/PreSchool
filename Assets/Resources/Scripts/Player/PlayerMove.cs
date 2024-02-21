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
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(h, v).normalized;
        gameObject.transform.position += moveDir * speed * Time.deltaTime;
    }

}
