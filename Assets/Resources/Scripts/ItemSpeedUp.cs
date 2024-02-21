using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeedUp : Item
{
    [SerializeField]
    float upSpeedMul = 1.5f;

    [SerializeField]
    float speedUpTimeSecond = 5f;

    float originSpeed = 1f;

    PlayerMove playerMove;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        //플레이어와 충돌했으면 
        if(collision.gameObject.CompareTag("Player"))
        {
            //먹은 상태
            eaten = true;
            playerMove = collision.GetComponent<PlayerMove>();
            //기존 속도 기록
            originSpeed = playerMove.Speed;
            //스피드 업
            playerMove.Speed = originSpeed * upSpeedMul;
            //아이템은 충돌 처리 해제, 렌더러 해제
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            //일정 시간 후 복구
            StartCoroutine(RestoreSpeed());
        }
    }

    public IEnumerator RestoreSpeed()
    {
        yield return new WaitForSeconds(speedUpTimeSecond);
        //스피드 복구
        playerMove.Speed = originSpeed;
        //게임 오브젝트 삭제
        Destroy(this.gameObject);
    }
}
