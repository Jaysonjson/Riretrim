using System;
using UnityEngine;

public class PlayerFuelCircle : MonoBehaviour
{
    public GameObject Player;

    private void FixedUpdate()
    {
        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(Player.transform.position);
    }
}
