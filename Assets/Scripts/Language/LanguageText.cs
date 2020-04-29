using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class LanguageText : MonoBehaviour
{
    public string value;
    private void Start()
    {
        if (value != null)
        {
            GetComponent<TextMeshProUGUI>().text = Registry.Language.GetType().GetField(value).GetValue(Registry.Language) as string;
        }
    }
}