using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class status : MonoBehaviour
{

    // ������
    public Slider slider;
    // �����ı�
    public Text text;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        void onProgress(int progress)
        {
            slider.value = progress;
        }
        text.text = (slider.value * 100).ToString("f0") + "%";

        //if () {

        //slider.value += 0.1f;
        //}
    }
}
