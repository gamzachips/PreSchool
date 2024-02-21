using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    //������
    [SerializeField]
    List<GameObject> lifeObjs;

    int maxLife = 5;
    int life = 5;

    //���� ����
    [SerializeField]
    float invincibleTimeSeconds = 2f;

    bool isInvincible = false;

    public int Life { get { return life; } }
    public void DecreaseLife()
    {
        //�������� 0�� �Ǹ� ���� �ƿ� 
        if (life <= 1)
        {
            //TODO
            //���� �ƿ�
            return;

        }
        //���� ���°� �ƴϸ� ������ ����
        if (!isInvincible)
        {
            life--;

            //������ ������Ʈ �� ���̰�
            lifeObjs[life - 1].gameObject.SetActive(false);

            //���� ���� ����
            isInvincible = true;
            StartCoroutine(InvincibleRelease());
        }
    }

    public void Start()
    {
        life = maxLife;
    }

    void Update()
    {
        
    }

    public IEnumerator InvincibleRelease()
    {
        yield return new WaitForSeconds(invincibleTimeSeconds);
    }
}
