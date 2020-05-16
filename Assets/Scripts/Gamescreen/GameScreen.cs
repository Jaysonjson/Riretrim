using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    public TextMeshProUGUI CurrencyText;

    void Update()
    {
        CurrencyText.text = Registry.profile.Data.currency + "";
    }
}
