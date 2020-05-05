using System;
using System.IO;
using UnityEngine;

public class ShopShip : MonoBehaviour
{
        public float xp = 1;
        public int price;
}

public class ShopShipData
{
        public bool bought = false;

        public void Load(string ship)
        {
                string json = "{}";
                if (File.Exists(Profile.profile_path + "/shop/" + "ships/" + ship + ".json"))
                {
                        json = File.ReadAllText(Profile.profile_path + "/shop/" + "ships/" + ship + ".json");
                }
                JsonUtility.FromJsonOverwrite(json, this);   
        }
        
        public void Save(string ship)
        {
                if (!Directory.Exists(Profile.profile_path + "/shop/" + "ships/"))
                {
                        Directory.CreateDirectory(Profile.profile_path + "/shop/" + "ships/");
                }
                File.WriteAllText(Profile.profile_path + "/shop/" + "ships/" + ship + ".json", JsonUtility.ToJson(this));
        }
}