using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; // 탄알 속력
    private Rigidbody2D bulletRigidbody; // 이동에 사용할 리지드바디 컴포넌트
    private Vector2 normal; // 충돌 지점의 법선 벡터
    private bool wallCollision = false; // 벽과 공의 충돌 감지
    private Vector2 direction;

    public Vector2 startPos; // 총알이 처음 생성되는 위치
    public Vector2 targetPos; // 총알이 향하는 목적지

    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody2D>();
       
        // Rigidbody의 회전을 제한
        bulletRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        

        // 총알이 생성되는 위치를 startPos로 설정
        transform.position = startPos;

        direction = (targetPos - startPos).normalized;

        // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.velocity = direction * speed;
    }

    // 충돌 시 충돌된 위치 가져오는 메서드
    void OnCollisionEnter2D(Collision2D col)
    {
        ContactPoint2D contact = col.contacts[0];

        // 충돌지점 오차를 줄이기 위한 반올림
        float currentPosX = (float)Math.Round(contact.point.x, 1);
        float currentPosY = (float)Math.Round(contact.point.y, 1);

        Vector2 currentPos = new Vector2(currentPosX, currentPosY); // 현재 총알의 위치
        normal = contact.normal;
        direction = Vector2.Reflect((currentPos - startPos).normalized, normal); // 반사 방향 계산
        Debug.Log(currentPos -  startPos);
        startPos = currentPos;
        wallCollision = true;
    }

    // 벽에 부딛혔을 시 반사되어 공이 날아가게 하는 메서드
    void BulletReflection()
    {
        bulletRigidbody.velocity = direction.normalized * speed;
    }

    private void Update()
    {
        if(wallCollision) // 벽에 충돌 시
        {
            BulletReflection();
            wallCollision = false;
        }
    }
}