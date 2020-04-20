using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMono : MonoBehaviour
{
    public GameObject sun;
    public GameObject redBlink;
    public GameObject redBlinkText;
    void Update()
    {
        Ship.bodyDamage += 0.0001f;
        Ship.gunDamage += 0.000000001f;
        Ship.thrusterDamage += 0.000001f;
        Ship.engineDamage += 0.0000001f;
        ShipDMGProgressbar.UpdateBars();

        if (sun != null)
        {
            float distance = Vector2.Distance(sun.transform.position, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
            if (distance < 12)
            {
                Ship.bodyDamage += 0.065f;
                Ship.gunDamage += 0.001f;
                Ship.thrusterDamage += 0.001f;
                Ship.engineDamage += 0.001f;
                redBlink.SetActive(true);
                redBlinkText.SetActive(true);
            }
            else
            {
                if (redBlink.active)
                {
                    redBlink.SetActive(false);
                    redBlinkText.SetActive(false);
                }
            }
        }
    }
}
