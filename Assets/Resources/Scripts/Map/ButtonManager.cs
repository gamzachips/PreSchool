using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Sprite[] sprites;
    int clickCount;
    int maxCount;

    public void ButtonClick()
    {
        clickCount++;
        if(clickCount > maxCount)
        {
            clickCount = 0;
            SceneManager.LoadScene("RoopAI");
        }
        else
        {
            GameObject.Find("ImageChange").GetComponent<Image>().sprite = sprites[clickCount];
        }
    }
    void Start()
    {
        GameObject.Find("ImageChange").GetComponent<Image>().sprite = sprites[0];
        maxCount = sprites.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}