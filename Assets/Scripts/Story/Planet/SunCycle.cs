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
    public UnityEngine.UI.Image sunHUD;
    public TextMeshProUGUI timeText;
    private float minutes;
    private float currentMinute;
    private float fakeTime;
    private void Start()
    {
        //Time.timeScale = 10;
        minutes = hourTime * 60;
        fakeTime = hourTime + 1;
        StartCoroutine(countMill());
        StartCoroutine(countTime());
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
    private void Update()
    {
        //sunLight.intensity = (float)hourTime / hours;
        timeText.text = hourTime + ":" + currentMinute;
        if (isDay() && !isNight())
        {
            sunHUD.fillAmount = ((float)fakeTime - sunStart) / sunEnd;
        }
        else
        {
            sunHUD.fillAmount = ((float)hourTime - 2) / (hours - 2);
        }
        // Debug.Log(DayLightPrecise());
        // Debug.Log(CurrentMinute());
        //Debug.Log(minutes + "_" + maxMinutes);
        Debug.Log(fakeTime);
    }

    public void Test()
    {
        string hourString;
        if (hourTime > 9)
        {
            hourString = hourTime.ToString() + currentMinute.ToString();
        }
        else
        {
            hourString = "0" + hourTime + currentMinute;
        }
        Debug.Log(hourString);
        Debug.Log((Convert.ToInt32(hourString) - (600) / (1800)));
    }
    public float DayLight()
    {
        return ((float)hourTime - sunStart) / sunEnd;
    }
    public float DayLightPrecise()
    {
        return (minutes - sunStart) * 60 / sunEnd * 60;
    }
    public float CurrentMinute()
    {
        return (minutes / hourTime);
    }

    IEnumerator countTime()
    {
        yield return new WaitForSeconds(60f);
        StartCoroutine(countTime());
    }

    IEnumerator countMill()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            fakeTime += 0.01f;
            if (minutes % 60 == 1)
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
            if (hourTime > 0)
            {
                minutes++;
            }
            if (hourTime == 0)
            {
                minutes = 0;
            }
        }
    }
}
