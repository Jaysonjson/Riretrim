using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InformationText : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = Application.productName + " " + Application.version + " | " + Application.companyName + " | " + SystemInfo.operatingSystem + " | " + Application.isEditor +  " | " + Application.unityVersion;
    }
}
