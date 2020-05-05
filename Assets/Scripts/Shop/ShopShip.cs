using System;
using System.IO;
using UnityEngine;

public class ShopShip : MonoBehaviour
{
        public float xp = 1;
        public int price;

        private void Start()
        {
                if (gameObject.name.Equals("Player"))
                {
                        ShopShipData shipData = new ShopShipData();
                        shipData.Load(gameObject.name);
                        shipData.bought = true;
                        shipData.Save(gameObject.name);
                }
        }
}

public class ShopShipData
{
        public bool bought = false;

        public void Load(string ship)
        {
                string json = "{}";
                if (File.Exists(Registry.profile.profile_path + "/shop/" + "ships/" + ship + ".json"))
                {
                        json = File.ReadAllText(Registry.profile.profile_path + "/shop/" + "ships/" + ship + ".json");
                }
                JsonUtility.FromJsonOverwrite(json, this);   
        }
        
        public void Save(string ship)
        {
                if (!Directory.Exists(Registry.profile.profile_path + "/shop/" + "ships/"))
                {
                        Directory.CreateDirectory(Registry.profile.profile_path + "/shop/" + "ships/");
                }
                File.WriteAllText(Registry.profile.profile_path + "/shop/" + "ships/" + ship + ".json", JsonUtility.ToJson(this, true));
        }
}