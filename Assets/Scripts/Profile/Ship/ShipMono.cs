using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class ShipMono : MonoBehaviour
{
    public GameObject sun;
    public GameObject redBlink;
    public GameObject redBlinkText;
    public GameObject wing;
    public GameObject ships;
    public ShipSprites Sprites;
    public ShipState STATE = ShipState.IDLE;
    private Random Random = new Random();
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject shipObject = GameObject.Find(Registry.profile.Ship.Data.body);
        shipObject.SetActive(true);
        Sprites = shipObject.GetComponent<ShipSprites>();
        Instantiate(shipObject, transform).SetActive(true);
        wing.GetComponent<SpriteRenderer>().color = Registry.profile.Ship.Data.wingColor;
        if (shipObject.name != "PlayerDefault")
        {
            GetComponent<Animator>().enabled = false;
            spriteRenderer.sprite = Sprites.Idle;
        }
        else if (shipObject.name == "PlayerDefault")
        {
            GetComponent<ShadowCaster2D>().enabled = true;
        }

        if (Sprites.Wing != null)
        {
            wing.GetComponent<SpriteRenderer>().sprite = Sprites.Wing;
        }
        else
        {
            wing.SetActive(false);
        }

        if (ships != null)
        {
            ships.SetActive(false);
        }

        if (shipObject.GetComponent<BoxCollider2D>() != null)
        {
            GetComponent<BoxCollider2D>().size = shipObject.GetComponent<BoxCollider2D>().size;
        }
    }

    void Update()
    {
        Registry.profile.Ship.Data.bodyDamage += 0.0001f;
        Registry.profile.Ship.Data.gunDamage += 0.000001f;
        Registry.profile.Ship.Data.thrusterDamage += 0.00001f;
        Registry.profile.Ship.Data.engineDamage += 0.00001f;
        if (Registry.profile.Ship.Data.on)
        {
            if (Registry.profile.Ship.Data.energy > 0)
            {
                Registry.profile.Ship.Data.energy -= 0.005f;
            }
            else
            {
                Registry.profile.Ship.Data.energy = 0;
            }
        }
        if (Random.Next(15) == 1)
        {
            Registry.profile.Data.ship_xp += 0.01f;
        }

        if (SceneManager.GetActiveScene().name.Equals("SpaceMap"))
        {
            ShipDMGProgressbar.INSTANCE.UpdateBars();
        }
        if (spriteRenderer != null && Sprites != null)
        {
            if (STATE == ShipState.IDLE)
            {
                spriteRenderer.sprite = Sprites.Idle;
            }

            if (STATE == ShipState.FLIGHT)
            {
                spriteRenderer.sprite = Sprites.Flight;
            }

            if (STATE == ShipState.SPECIAL)
            {
                spriteRenderer.sprite = Sprites.Special;
            }
        }
        if (sun != null && redBlink != null)
        {
            float distance = Vector2.Distance(sun.transform.position, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
            if (distance < 12)
            {
                Registry.profile.Ship.Data.bodyDamage += 0.065f;
                Registry.profile.Ship.Data.gunDamage += 0.00035f;
                Registry.profile.Ship.Data.thrusterDamage += 0.00069f;
                Registry.profile.Ship.Data.engineDamage += 0.00094f;
                redBlink.SetActive(true);
                redBlinkText.SetActive(true);
            }
            else
            {
                if (redBlink.activeSelf)
                {
                    redBlink.SetActive(false);
                    redBlinkText.SetActive(false);
                }
            }
        }
    }
}
