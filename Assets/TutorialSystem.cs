using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialSystem : MonoBehaviour
{
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    [SerializeField]
    GameObject[] itemPrefabs;

    GameObject[] itemObjects;

    [SerializeField]
    string[] showText;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject panel;

    //laser
    [SerializeField] GameObject indicator;
    [SerializeField] float indicatorTime;
    [SerializeField] GameObject laser;
    [SerializeField] float laserTime;

    TextMeshProUGUI textMesh;

    int nowIdx = 0;
    bool isShowing = false;

    private void Start()
    {
        textMesh = panel.GetComponentInChildren<TextMeshProUGUI>();
        textMesh.SetText(showText[nowIdx]);
        isShowing = true;

        itemObjects = new GameObject[itemPrefabs.Length];
        AudioManager.Instance.PlayTutorialMusic();
    }

    private void Update()
    {
        if (nowIdx == 0 && isShowing)
        {
            if (Input.GetKeyDown(KeyCode.Z) || (Input.GetKeyDown(KeyCode.Return)))
            {
                isShowing = false;
                HideText();
                ItemSpawn();
            }
        }
        else if (nowIdx == 0 && !isShowing)
        {
            if (CheckItemDone())
            {
                ShowNextText();
            }
        }
        else if (nowIdx == 1 && isShowing)
        {
            if (Input.GetKeyDown(KeyCode.Z) || (Input.GetKeyDown(KeyCode.Return)))
            {
                HideText();
                StartCoroutine(LaserSpawn());
            }
        }
        else if (nowIdx == 2 || nowIdx == 3)
        {
            if (Input.GetKeyDown(KeyCode.Z) || (Input.GetKeyDown(KeyCode.Return)))
                ShowNextText();
        }
        else if (nowIdx == 4)
        {
            if (Input.GetKeyDown(KeyCode.Z) || (Input.GetKeyDown(KeyCode.Return)))
            {
                HideText();
                // AudioManager.Instance.PlayTutorialMusic();
            }


            //start game
        }
    }

    bool CheckItemDone()
    {
        foreach (GameObject item in itemObjects)
        {
            if (item != null)
                return false;
        }
        return true;
    }

    void ItemSpawn()
    {
        for (int i = 0; i < itemPrefabs.Length; i++)
        {

            GameObject itemObject = Instantiate(itemPrefabs[i]);
            itemObjects[i] = itemObject;
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            itemObject.transform.position = new Vector3(randomX, randomY, 0);
        }
    }

    IEnumerator LaserSpawn()
    {
        //TODO
        indicator.SetActive(true);
        StartCoroutine(LaserSpawner());
        yield return new WaitForSeconds(4f);
        ShowNextText();
    }

    private void ShowNextText()
    {
        if (nowIdx < showText.Length - 1)
        {
            nowIdx++;
            player.GetComponent<PlayerLife>().playerstate = PlayerLife.PlayerState.interactive;
            panel.SetActive(true);
            textMesh.SetText(showText[nowIdx]);
            isShowing = true;
            AudioManager.Instance.PauseMusic();
        }
    }

    private void HideText()
    {
        panel.SetActive(false);
        if (player == null) return;
        player.gameObject.GetComponent<PlayerLife>().playerstate = PlayerLife.PlayerState.life;
        isShowing = false;
        AudioManager.Instance.ContinueMusic();
    }

    IEnumerator LaserSpawner()
    {
        indicator.SetActive(true);
        yield return new WaitForSeconds(indicatorTime);
        indicator.SetActive(false);
        laser.SetActive(true);
        yield return new WaitForSeconds(laserTime);
        laser.SetActive(false);
    }
}

