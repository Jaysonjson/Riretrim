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
    }
    void Update()
    {
        if(splashText.Equals("3D"))
        {
            transform.Rotate(Vector3.up * 45.5f * Time.deltaTime, Space.Self);
        }
        if(splashText.Equals("Color"))
        {
            if (rand.Next(10) == 1)
            {
                GetComponent<TextMeshProUGUI>().color = new Color32((byte)(rand.Next(255)), (byte)(rand.Next(255)), (byte)(rand.Next(255)), 255);
            }
        }
    }
}
