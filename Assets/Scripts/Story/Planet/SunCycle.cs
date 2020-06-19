using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using TMPro;
public class SunCycle : MonoBehaviour
{
    public Light2D sunLight;
    public float hours = 24;
    public float sunStart = 6;
    public float sunEnd = 18;
    public int hourTime = 6;
    //public UnityEngine.UI.Image sunHUD;
    public TextMeshProUGUI timeText;
    private float minutes;
    private float currentMinute;
    private float fakeTime;
    private void Start()
    {
        Time.timeScale = 10;
        minutes = hourTime * 60;
        fakeTime = hourTime + 1;
        StartCoroutine(CycleCour());
    }
    private bool isDay()
    {
        if (hourTime >= sunStart && !isNight())
        {
            return true;
        }
        return false;
    }
    private bool isNight()
    {
        if (hourTime >= sunEnd || hourTime < sunStart)
        {
            return true;
        }
        return false;
    }

    IEnumerator CycleCour()
    {
        yield return new WaitForSecondsRealtime(1f);
        if ((int)currentMinute >= 59)
        {
            if (hourTime < hours)
            {
                hourTime++;
            }
            if (hourTime >= hours)
            {
                hourTime = 0;
            }
        }
        if (currentMinute < 60)
        {
            currentMinute++;
        }
        if (currentMinute >= 60)
        {
            currentMinute = 0;
        }
        if (hourTime == 0)
        {
            minutes = 0;
        }
        fakeTime = hourTime + (currentMinute / 100);
        if (currentMinute.ToString().Length > 1)
        {
            timeText.text = hourTime + ":" + (int)currentMinute;
        }
        else
        {
            timeText.text = hourTime + ":0" + (int)currentMinute;
        }
        if (isDay() && !isNight())
        {
            //sunHUD.fillAmount = (fakeTime - sunStart) / sunEnd - hours;
            //Debug.Log((fakeTime) / sunEnd);
            Debug.Log((fakeTime - sunStart) / sunEnd - hours);
        }
        else
        {
            //sunHUD.fillAmount = (fakeTime - 2) / (hours - 2);
        }
        StartCoroutine(CycleCour());
    }

    public void Cycle()
    {
        minutes += (Time.deltaTime);
        //if (minutes % 60 == 1)
        Debug.Log((int)currentMinute >= 59);
        if ((int)currentMinute >= 59)
        {
            if (hourTime < hours)
            {
                hourTime++;
            }
            if (hourTime >= hours)
            {
                hourTime = 0;
            }
        }
        if (currentMinute < 60)
        {
            currentMinute += (Time.deltaTime);
        }
        if (currentMinute >= 60)
        {
            currentMinute = 0;
        }
        if (hourTime == 0)
        {
            minutes = 0;
        }
    }
}
