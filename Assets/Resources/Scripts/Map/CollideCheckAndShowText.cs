using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CollideCheckAndShowText : MonoBehaviour
{
    [SerializeField]
    GameObject panel;

    [SerializeField]
    string[] showText;

    int nowIdx = 0;
    TextMeshProUGUI textMesh;

    bool isStaying = false;
    bool isInteracting = false;
    GameObject player;

    private void Start()
    {
        textMesh = panel.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (isStaying)
        {
            if (Input.GetKeyDown(KeyCode.Z) || (Input.GetKeyDown(KeyCode.Return)))
            {
                if (nowIdx < showText.Length)
                {
                    //플레이어 움직임 막음
                    player.GetComponent<PlayerLife>().playerstate = PlayerLife.PlayerState.interactive;
                    //텍스트창 띄움
                    panel.SetActive(true);
                    //텍스트 설정
                    textMesh.SetText(showText[nowIdx]);

                    nowIdx++;
                }
                else
                {
                    panel.SetActive(false);
                    if (player == null) return;
                    player.gameObject.GetComponent<PlayerLife>().playerstate = PlayerLife.PlayerState.life;
                    nowIdx = 0;
                }

            }
        }
       

        if (Input.GetKey(KeyCode.Escape) && isInteracting)
        {
            panel.SetActive(false);
            isInteracting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            isStaying = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            isStaying = false;
        }
    }


}
