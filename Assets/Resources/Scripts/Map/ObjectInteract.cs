using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ObjectInteract : MonoBehaviour
{
    //텍스트 표시 패널
    [SerializeField]
    GameObject panel;

    //보여줄 텍스트 목록
    [TextArea]
    [SerializeField]
    string[] showText;

    //스테이지 연결하는 경우 선택
    [SerializeField]
    ScneManager.SceneType nextScene = ScneManager.SceneType.None;

    [SerializeField]
    GradeType clearGradeType = GradeType.C;

    [SerializeField]
    bool stageConnected = false;
    //클리어했을 때 뜨는 텍스트 - 바로 스테이지 연결
    [SerializeField]
    int stageConnectIdx = 0;

    //현재 텍스트 
    int nowIdx = 0;

    TextMeshProUGUI textMesh;

    bool isStaying = false;
    public bool isInteracting = false;
    GameObject player;

    private void Start()
    {
        textMesh = panel.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        
        
        Debug.Log("isStaying : " + isStaying);
        Debug.Log("isInteracting : " + isInteracting);
        if (isStaying)
        {
            if (player.GetComponent<PlayerLife>().playerstate == PlayerLife.PlayerState.pause) return;
            if (Input.GetKeyDown(KeyCode.Z) || (Input.GetKeyDown(KeyCode.Return)))
            {
                isInteracting = true;
                int finalIdx = showText.Length - 1;
                if(stageConnectIdx != -1)
                    finalIdx = stageConnectIdx - 1;

                char rank;
                int score;
                //기존에 상호작용중이 아니고 스테이지를 플레이했었다면
                if(SaveManager.Instance.GetRankAndScore(nextScene, out rank, out score)
                    && rank.ToString()[0] <= clearGradeType.ToString()[0]
                    && player.GetComponent<PlayerLife>().playerstate != PlayerLife.PlayerState.interactive)
                {
                    //바로 스테이지 텍스트
                    nowIdx = stageConnectIdx;
                    finalIdx = stageConnectIdx;
                }

                //마지막으로 지정된 인덱스까지 텍스트 출력
                if (nowIdx <= finalIdx)
                {
                    player.GetComponent<PlayerLife>().playerstate = PlayerLife.PlayerState.interactive;
                    panel.SetActive(true);
                    textMesh.SetText(showText[nowIdx]);

                    if(stageConnectIdx != -1 && nowIdx == stageConnectIdx)
                        textMesh.SetText(textMesh.text + '\n' 
                        + "[내 최고 기록] "
                        + rank + "랭크 "
                        + score.ToString() + "점");

                    nowIdx++;
                }
                else //다 출력했으면 닫음
                {
                    panel.SetActive(false);
                    if (player == null) return;
                    player.gameObject.GetComponent<PlayerLife>().playerstate = PlayerLife.PlayerState.life;
                    nowIdx = 0;

                    //전환할 씬이 있다면 전환
                    if(stageConnected && nextScene != ScneManager.SceneType.None)
                    {
                        ScneManager.Instance.ChangeSceneByType(nextScene);
                    }
                }
            }
        }
       
        if (Input.GetKeyDown(KeyCode.Escape) && isInteracting)
        {
            Debug.Log("Check ESC");
            panel.SetActive(false);
            isInteracting = false;
            StartCoroutine(ResumeplayerState());
            nowIdx = 0;
        }
    }

    IEnumerator ResumeplayerState()
    {
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<PlayerLife>().playerstate = PlayerLife.PlayerState.life;

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



