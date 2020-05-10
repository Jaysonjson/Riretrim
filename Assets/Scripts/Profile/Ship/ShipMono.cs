using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Random = System.Random;

public class ShipMono : MonoBehaviour
{
    public GameObject sun;
    public GameObject redBlink;
    public GameObject redBlinkText;
    public GameObject wing;
    public GameObject ships;
    private ShipSprites Sprites;
    public ShipState STATE = ShipState.IDLE;
    private Random Random = new Random();
    void Start()
    {
        GameObject shipObject = GameObject.Find(Ship.body);
        shipObject.SetActive(true);
        Sprites = shipObject.GetComponent<ShipSprites>();
        Instantiate(shipObject,transform).SetActive(true);
        if (shipObject.name != "PlayerDefault")
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = Sprites.Idle;
        }
        else if(shipObject.name == "PlayerDefault")
        {
            GetComponent<ShadowCaster2D>().enabled = true;
        }

        if (Sprites.Wing != null)
        {
            wing.GetComponent<SpriteRenderer>().sprite = Sprites.Wing;
        }

        if (ships != null)
        {
            ships.SetActive(false);
        }
    }

    void Update()
    {
        Ship.Data.bodyDamage += 0.0001f;
        Ship.Data.gunDamage += 0.000001f;
        Ship.Data.thrusterDamage += 0.00001f;
        Ship.Data.engineDamage += 0.00001f;
        if (Random.Next(15) == 1)
        {
            Registry.profile.Data.ship_xp += 0.01f;
        }

        ShipDMGProgressbar.INSTANCE.UpdateBars();
        if (STATE == ShipState.IDLE)
        {
            GetComponent<SpriteRenderer>().sprite = Sprites.Idle;
        }

        if (STATE == ShipState.FLIGHT)
        {
            GetComponent<SpriteRenderer>().sprite = Sprites.Flight;
        }

        if (sun != null)
        {
            float distance = Vector2.Distance(sun.transform.position, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
            if (distance < 12)
            {
                Ship.Data.bodyDamage += 0.065f;
                Ship.Data.gunDamage += 0.00035f;
                Ship.Data.thrusterDamage += 0.00069f;
                Ship.Data.engineDamage += 0.00094f;
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
