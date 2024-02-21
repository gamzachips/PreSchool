using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCheck : MonoBehaviour
{

    Slider slider;

    [SerializeField]
    ScoreSystem scoreSystem;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);

        slider.value = scoreSystem.Score;
    }
}
