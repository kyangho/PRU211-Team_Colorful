using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{

    public Text timerCounter;

    public float currentTime;

    private TimeFormat timeFormat;


    // Start is called before the first frame update
    void Start()
    {
    }

   
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");
        timerCounter.text = "Time: " + String.Format("{0}:{1}", minutes, seconds);
    }
}
