using System.Collections;
using TMPro;
using UnityEngine;

public class SplashText : MonoBehaviour
{
    string[] splashs = {
        "3D",
        "Color"
    };
    string splashText;
    System.Random rand = new System.Random();  
    void Start()
    {
        splashText = $"{splashs[rand.Next(splashs.Length)]}";
        GetComponent<TextMeshProUGUI>().text = splashText;
        if (splashText.Equals("Color"))
        {
            StartCoroutine(colorSplash());
        }
    }
    void Update()
    {
        if(splashText.Equals("3D"))
        {
            transform.Rotate(Vector3.up * 45.5f * Time.deltaTime, Space.Self);
        }
    }

    IEnumerator colorSplash()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<TextMeshProUGUI>().color = new Color32((byte)(rand.Next(255)), (byte)(rand.Next(255)), (byte)(rand.Next(255)), 255);
        StartCoroutine(colorSplash());
    }
}
