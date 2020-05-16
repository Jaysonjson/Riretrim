using System;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public int lifetime;
    private int currentLifetime;

    private void Update()
    {
        currentLifetime++;
        if (currentLifetime >= lifetime)
        {
            Debug.Log(gameObject.name + " exceeded it's lifetime. (" + lifetime + ")");
            Destroy(gameObject);
        }
    }
}
