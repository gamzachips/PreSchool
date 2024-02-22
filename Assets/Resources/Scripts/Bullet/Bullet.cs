using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; // ź�� �ӷ�
    private Rigidbody2D bulletRigidbody; // �̵��� ����� ������ٵ� ������Ʈ
    private Vector2 normal; // �浹 ������ ���� ����
    private bool wallCollision = false; // ���� ���� �浹 ����
    private Vector2 direction;

    public Vector2 startPos; // �Ѿ��� ó�� �����Ǵ� ��ġ
    public Vector2 targetPos; // �Ѿ��� ���ϴ� ������

    void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody2D>();
       
        // Rigidbody�� ȸ���� ����
        bulletRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        

        // �Ѿ��� �����Ǵ� ��ġ�� startPos�� ����
        transform.position = startPos;

        direction = (targetPos - startPos).normalized;

        // ������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�
        bulletRigidbody.velocity = direction * speed;
    }

    // �浹 �� �浹�� ��ġ �������� �޼���
    void OnCollisionEnter2D(Collision2D col)
    {
        ContactPoint2D contact = col.contacts[0];

        // �浹���� ������ ���̱� ���� �ݿø�
        float currentPosX = (float)Math.Round(contact.point.x, 1);
        float currentPosY = (float)Math.Round(contact.point.y, 1);

        Vector2 currentPos = new Vector2(currentPosX, currentPosY); // ���� �Ѿ��� ��ġ
        normal = contact.normal;
        direction = Vector2.Reflect((currentPos - startPos).normalized, normal); // �ݻ� ���� ���
        Debug.Log(currentPos -  startPos);
        startPos = currentPos;
        wallCollision = true;
    }

    // ���� �ε����� �� �ݻ�Ǿ� ���� ���ư��� �ϴ� �޼���
    void BulletReflection()
    {
        bulletRigidbody.velocity = direction.normalized * speed;
    }

    private void Update()
    {
        if(wallCollision) // ���� �浹 ��
        {
            BulletReflection();
            wallCollision = false;
        }
    }
}