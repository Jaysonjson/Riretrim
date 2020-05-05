using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMono : MonoBehaviour
{
    public GameObject sun;
    public GameObject redBlink;
    public GameObject redBlinkText;
    public GameObject wing;
    private ShipStateFlight ShipStateFlight;
    private ShipStateIdle ShipStateIdle;
    private ShipStateWing ShipStateWing;
    public ShipState STATE = ShipState.IDLE;
    void Start()
    {
        GameObject shipObject = GameObject.Find(Ship.body);
        ShipStateFlight = shipObject.GetComponent<ShipStateFlight>();
        ShipStateIdle = shipObject.GetComponent<ShipStateIdle>();
        ShipStateWing = shipObject.GetComponent<ShipStateWing>();
        Instantiate(shipObject,transform).SetActive(true);
        if (shipObject.name != "PlayerDefault")
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = ShipStateIdle.sprite;
        }

        if (ShipStateWing.sprite != null)
        {
            wing.GetComponent<SpriteRenderer>().sprite = ShipStateWing.sprite;
        }
    }

    void Update()
    {
        Ship.bodyDamage += 0.0001f;
        Ship.gunDamage += 0.000000001f;
        Ship.thrusterDamage += 0.000001f;
        Ship.engineDamage += 0.0000001f;
        Profile.ship_xp += 0.000001f;
        ShipDMGProgressbar.INSTANCE.UpdateBars();
        if (STATE == ShipState.IDLE)
        {
            GetComponent<SpriteRenderer>().sprite = ShipStateIdle.sprite;
        }

        if (STATE == ShipState.FLIGHT)
        {
            GetComponent<SpriteRenderer>().sprite = ShipStateFlight.sprite;
        }
        
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
