using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDControlTutorial : MonoBehaviour
{
    public GameObject timeText;
    public GameObject movementText;
    public bool timeTextDone;
    public bool movementDone;
    public bool allDone = false;
    private void Start()
    {
        gameObject.SetActive(true);
    }
    private void Update()
    {
        if (!movementDone)
        {
            movementText.SetActive(true);
        }
        else
        {
            movementText.SetActive(false);
        }
        if (!timeTextDone && movementDone)
        {
            timeText.SetActive(true);
        }
        else
        {
            timeText.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            timeTextDone = true;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            movementDone = true;
        }
        if (allDone)
        {
            gameObject.SetActive(false);
        }
    }
}
