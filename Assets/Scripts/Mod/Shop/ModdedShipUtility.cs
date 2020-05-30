using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class ModdedShipUtility 
{
    public static List<ModdedShipData> GetDatas() {
        string[] files = Directory.GetFiles(Registry.profile.mod_path + "ships");
        List<ModdedShipData> datas = new List<ModdedShipData>();
        for (int i = 0; i < files.Length; i++)
        {
            if(files[i].Contains("shipobject")) {
                ModdedShipData moddedShipData = new ModdedShipData();
                moddedShipData.Load(files[i]);
                datas.Add(moddedShipData);
            }
        }
        return datas;
    }

    public static List<Sprite> GetSprites(List<ModdedShipData> data) {
        List<Sprite> sprites = new List<Sprite>();
        for (int i = 0; i < data.Count; i++)
        {
                Texture2D shipSprite = new Texture2D(64, 64);
                shipSprite.LoadImage(File.ReadAllBytes(Registry.profile.mod_path + "ships/" + data[i].sprite));
                shipSprite.filterMode = FilterMode.Point;
                shipSprite.name = data[i].name;
                //shipSprite.Resize(64, 64);
                Sprite shipSpriteTex = Sprite.Create(shipSprite, new Rect(0, 0, shipSprite.width, shipSprite.height), new Vector2(0.5f, 0.5f), 100);
                sprites.Add(shipSpriteTex);
        }
        return sprites;
    }

    public static List<ModdedShip> GetShips() {
        List<ModdedShip> ships = new List<ModdedShip>();
        string[] files = Directory.GetFiles(Application.persistentDataPath + "/mods/" + "ships");
        for (int i = 0; i < files.Length; i++)
        {
            if(files[i].Contains("shipobject")) {
                ModdedShipData moddedShipData = new ModdedShipData();
                moddedShipData.Load(files[i]);
                ModdedShip moddedShip = new ModdedShip();
                moddedShip.data = moddedShipData;
                if(moddedShipData.sprite != "") 
                {
                Texture2D shipSprite = new Texture2D(64, 64);
                shipSprite.LoadImage(File.ReadAllBytes(Application.persistentDataPath + "/mods/" + "ships/" + moddedShipData.sprite));
                shipSprite.filterMode = FilterMode.Point;
                shipSprite.name = moddedShipData.name;
                //shipSprite.Resize(64, 64);
                Sprite shipSpriteTex = Sprite.Create(shipSprite, new Rect(0, 0, shipSprite.width, shipSprite.height), new Vector2(0.5f, 0.5f), 100);
                moddedShip.sprite = shipSpriteTex;
                }
                Debug.Log("Added Ship: " + moddedShip.data.name);
                ships.Add(moddedShip);
            }
        }
        return ships;
    }
    public static ModdedShip FindShip(string name, List<ModdedShip> shipList) {
        ModdedShip moddedShip = new ModdedShip();
        for (int i = 0; i < shipList.Count; i++)
        {
            if(shipList[i].data.name == name) {
                moddedShip = shipList[i];
                break;
            }
        }

        return moddedShip;
    }
}