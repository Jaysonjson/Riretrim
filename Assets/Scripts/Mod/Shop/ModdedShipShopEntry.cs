using System.Net;
using System;
using UnityEngine;
using System.IO;
public class ModdedShipShopEntry : MonoBehaviour 
{
    public GameObject moddedShip;
    public Shop shop;
    private void Start()
    {
        string[] files = Directory.GetFiles(Registry.profile.mod_path + "ships");
        for (int i = 0; i < files.Length; i++)
        {
            if(files[i].Contains("shipobject")) {
                Debug.Log("Found Ship Mod: " + files[i] + " creating Object...");
                GameObject ship = Instantiate(moddedShip);
                ModdedShipData moddedShipData = new ModdedShipData();
                moddedShipData.Load(files[i]);
                if(moddedShipData.sprite != "") {
                    Debug.Log("Creating Sprite");
                    Texture2D shipSprite = new Texture2D(64, 64);
                    shipSprite.LoadImage(File.ReadAllBytes(Registry.profile.mod_path + "ships/" + moddedShipData.sprite));
                    shipSprite.filterMode = FilterMode.Point;
                    //shipSprite.Resize(64, 64);
                    Sprite shipSpriteTex = Sprite.Create(shipSprite, new Rect(0, 0, shipSprite.width, shipSprite.height), new Vector2(0, 0), 100);
                    ship.GetComponent<SpriteRenderer>().sprite = shipSpriteTex;
                }
                ship.GetComponent<ShopShip>().xp = moddedShipData.xp;
                ship.GetComponent<ShopShip>().price = moddedShipData.price;
                ship.name = moddedShipData.name;
                shop.ships.Add(ship);
            }
        }
    }
}