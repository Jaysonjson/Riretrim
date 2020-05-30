using System.Net;
using System;
using UnityEngine;
using System.IO;
public class ModdedShipShopEntry : MonoBehaviour 
{
    public GameObject moddedShipObject;
    public Shop shop;
    private void Start()
    {
        for (int i = 0; i < Mods.ships.Count; i++)
        {
            ModdedShip moddedShip = Mods.ships[i];
            GameObject ship = Instantiate(moddedShipObject);
            ship.GetComponent<SpriteRenderer>().sprite = moddedShip.sprite;
            ship.GetComponent<ShopShip>().xp = moddedShip.data.xp;
            ship.GetComponent<ShopShip>().price = moddedShip.data.price;
            ship.GetComponent<ShopShip>().modded = true;
            ship.name = moddedShip.data.name;
            shop.ships.Add(ship);
        }
    }
}