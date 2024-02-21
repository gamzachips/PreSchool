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
        //�÷��̾�� �浹������ 
        if(collision.gameObject.CompareTag("Player"))
        {
            //���� ����
            eaten = true;
            playerMove = collision.GetComponent<PlayerMove>();
            //���� �ӵ� ���
            originSpeed = playerMove.Speed;
            //���ǵ� ��
            playerMove.Speed = originSpeed * upSpeedMul;
            //�������� �浹 ó�� ����, ������ ����
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            //���� �ð� �� ����
            StartCoroutine(RestoreSpeed());
        }
    }

    public IEnumerator RestoreSpeed()
    {
        yield return new WaitForSeconds(speedUpTimeSecond);
        //���ǵ� ����
        playerMove.Speed = originSpeed;
        //���� ������Ʈ ����
        Destroy(this.gameObject);
    }
}
