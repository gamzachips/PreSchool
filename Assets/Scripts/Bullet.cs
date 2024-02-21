using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; // ź�� �ӷ�
    private Rigidbody2D bulletRigidbody; // �̵��� ����� ������ٵ� ������Ʈ
    private Transform bulletTransform;
    private Vector2 pos; // �浹 ���� ��ǥ
    private Vector2 normal; // �浹 ������ ���� ����
    private bool wallCollision = false;

    private bool isFirstBounce = true;

    void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody2D>();

        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletTransform = GetComponent<Transform>();

        // ������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�
        bulletRigidbody.velocity = transform.up * speed;
    }

    // �浹 �� �浹�� ��ġ �������� �޼���
    void OnCollisionEnter2D(Collision2D col)
    {
        ContactPoint2D contact = col.contacts[0];
        pos = contact.point;
        normal = contact.normal;
        Debug.Log("�浹 ����: " + pos);
        Debug.Log("���� ����: " + normal);
        Debug.Log(bulletRigidbody.velocity);
        wallCollision = true;
    }

    void BulletReflection(Vector2 pos)
    {
        bulletRigidbody.velocity = pos * normal * speed ;
    }

    private void Update()
    {
        // transform.Translate(pos * speed * Time.deltaTime);

        if (wallCollision)
        {
            Debug.Log(bulletRigidbody.velocity);
            BulletReflection(pos);
            wallCollision = false;
            isFirstBounce = false;
        }
        if(isFirstBounce)
        {
            transform.Translate(pos * speed * Time.deltaTime);
        }
    }
}