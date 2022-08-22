using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Text clockText;

    private float timer = 0f;

    private void Update()
    {
        /*timer += Time.deltaTime * 10f;
        int totalSeconds = Mathf.RoundToInt(timer);
        //150s => 02:30
        int minute = totalSeconds / 60;
        int second = totalSeconds - minute * 60;
        clockText.text = ((minute < 10) ? "0" : "") + minute.ToString() + ":" + ((second < 10) ? "0" : "") + second.ToString();*/

        clockText.text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
    }
}
