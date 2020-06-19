using System;
using UnityEngine;
using UnityEngine.UI;

public class GunTemperatureProgressbar : MonoBehaviour
{
    public GSPlayer Player;

    private void Start()
    {
        UpdateBar();
    }

    public void UpdateBar()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(((float) Player.gun_temperature / Player.max_gun_temperature) * 100, rectTransform.sizeDelta.y);
    }
}