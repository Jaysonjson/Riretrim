using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{ void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "FPS: " + (1.0f / Time.deltaTime) + "";
    }
}
