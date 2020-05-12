using System;
using TMPro;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshPro>().text = "Heat Resistance: " + Registry.profile.Ship.Data.heatResistance + "°C";
    }
}