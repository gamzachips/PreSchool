using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGradeImage : MonoBehaviour
{
    ScoreSystem scoreSystem;

    [SerializeField]
    Sprite[] gradeSprites;

    private void Start()
    {
    }

    private void Update()
    {
        gameObject.GetComponent<Image>().sprite = gradeSprites[(int)ScoreSystem.Instance.Grade];
    }
}
