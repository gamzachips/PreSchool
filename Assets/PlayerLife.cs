using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    //라이프
    [SerializeField]
    List<GameObject> lifeObjs;

    int maxLife = 5;
    int life = 5;

    //무적 상태
    [SerializeField]
    float invincibleTimeSeconds = 2f;

    bool isInvincible = false;

    public int Life { get { return life; } }
    public void DecreaseLife()
    {
        //라이프가 0이 되면 게임 아웃 
        if (life <= 1)
        {
            //TODO
            //게임 아웃
            return;

        }
        //무적 상태가 아니면 라이프 감소
        if (!isInvincible)
        {
            life--;

            //라이프 오브젝트 안 보이게
            lifeObjs[life - 1].gameObject.SetActive(false);

            //무적 상태 설정
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
