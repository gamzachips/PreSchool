using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject[] musicObjects;

    [SerializeField]
    float time;

    int idx = 0;
  
    void Start()
    {
        StartCoroutine(ShowMusic());
    }

    IEnumerator ShowMusic()
    {
        while(true)
        {
            foreach (GameObject obj in musicObjects)
            {
                obj.SetActive(false);
            }
            yield return new WaitForSeconds(time);

            while (idx < musicObjects.Length)
            {
                musicObjects[idx].SetActive(true);
                idx++;
                yield return new WaitForSeconds(time);
            }

            idx = 0;
        }
    }
}
