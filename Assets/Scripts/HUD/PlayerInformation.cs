using System;
using TMPro;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshPro>().text = "Heat Resistance: " + Ship.heatResistance + "°C";
    }
}