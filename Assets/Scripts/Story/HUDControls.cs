using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDControls : MonoBehaviour
{
    public GameObject timeText;
    private void Update()
    {
        //Time
        if (Input.GetKey(KeyCode.T))
        {
            timeText.SetActive(true);
        }
        //Time
        if (Input.GetKeyUp(KeyCode.T))
        {
            timeText.SetActive(false);
        }
    }
}
