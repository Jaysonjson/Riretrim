using System;
using UnityEngine;

public class Watchluck : MonoBehaviour
{
    public bool fast = false;
    public float timeChange = 3;
    public void Start()
    {
        System.Random random = new System.Random();
        fast = false;
        timeChange = 1 +  random.Next(3) + (float)random.NextDouble();
        if (random.Next(2) == 1)
        {
            fast = true;
        }
        if(GetComponent<SingleMovement>() != null)
        {
            GetComponent<SingleMovement>().movement = (float)random.NextDouble() / 1000;
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1; 
    }

    private void OnBecameInvisible()
    {
        Time.timeScale = 1;
    }
}
