using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CurrencyLight : MonoBehaviour
{
    public Light2D parLight0;
    public Light2D parLight1;
    private void Update()
    {
        parLight0.transform.Rotate(Vector3.forward * 0.5f * Time.deltaTime, Space.Self);
        parLight1.transform.Rotate(Vector3.forward * 0.5f * Time.deltaTime, Space.Self);
    }
}
