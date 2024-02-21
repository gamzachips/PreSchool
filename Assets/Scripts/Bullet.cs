using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; // 탄알 속력
    private Rigidbody2D bulletRigidbody; // 이동에 사용할 리지드바디 컴포넌트
    private Transform bulletTransform;
    private Vector2 pos; // 충돌 지점 좌표
    private Vector2 normal; // 충돌 지점의 법선 벡터
    private bool wallCollision = false;

    private bool isFirstBounce = true;

    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody2D>();

        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletTransform = GetComponent<Transform>();

        // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.velocity = transform.up * speed;
    }

    // 충돌 시 충돌된 위치 가져오는 메서드
    void OnCollisionEnter2D(Collision2D col)
    {
        ContactPoint2D contact = col.contacts[0];
        pos = contact.point;
        normal = contact.normal;
        Debug.Log("충돌 지점: " + pos);
        Debug.Log("법선 벡터: " + normal);
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