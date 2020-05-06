using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(Options.Data.ShowFPS);
    }

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "FPS: " + (1.0f / Time.deltaTime) + "";
    }
}
