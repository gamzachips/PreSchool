using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    public void RetryButtonClick()
    {
        ScneManager.Instance.ChangeSceneByType(GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().sceneType);
    }
}
