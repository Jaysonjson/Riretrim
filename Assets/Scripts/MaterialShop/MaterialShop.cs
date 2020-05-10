using System;
using TMPro;
using UnityEngine;

public class MaterialShop : MonoBehaviour
{
    public TextMeshProUGUI CurrencyText;

    private void Start()
    {
        CurrencyText.text = Registry.profile.Data.currency + "";
    }

    private void Update()
    {
        CurrencyText.text = Registry.profile.Data.currency + "";
    }
}
