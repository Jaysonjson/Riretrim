using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedLifeTime : MonoBehaviour
{
    public int lifetime;
    private int currentLifetime;

    private void FixedUpdate()
    {
        currentLifetime++;
        if (currentLifetime >= lifetime)
        {
            Debug.Log(gameObject.name + " exceeded it's fixed lifetime. (" + lifetime + ")");
            Destroy(gameObject);
        }
    }
}
