using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Ship
{
    public ShipData Data = new ShipData();

    public void Load()
    {
        Data.Load();
    }

    public void Save()
    {
        Data.Save();
    }
}

public class ShipData
{
    public float heatResistance = 1538f;

    public float thrusterDamage = 0f;
    public float engineDamage = 0f;
    public float gunDamage = 0f;
    public float bodyDamage = 0f;

    public float thrusterDamageMax = 200f;
    public float engineDamageMax = 200f;
    public float gunDamageMax = 200f;
    public float bodyDamageMax = 200f;

    public string body = "PlayerDefault"; //PlayerDefault

    public float energy = 125f;
    public float fuel = 250f;
    public float fuelMax = 250f;
    public float energyMax = 125f;

    public bool on = true;
    
    public void Load()
    {
        string json = "{}";
        if (File.Exists(Application.persistentDataPath + "/profiles/" + References.current_profile + "/ship.json"))
        {
            json = File.ReadAllText(Application.persistentDataPath + "/profiles/" + References.current_profile + "/ship.json");
        }
        else
        {
            Save();
        }
        JsonUtility.FromJsonOverwrite(json, this);   
    }
        
    public void Save()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/profiles/" + References.current_profile + "/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/profiles/" + References.current_profile + "/");
        }
        File.WriteAllText(Application.persistentDataPath + "/profiles/" + References.current_profile + "/ship.json", JsonUtility.ToJson(this, true));
    }
}