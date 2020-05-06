using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Map
{
    public static MapData Data = new MapData();
    public static void Load()
    {
        Data.Load();
    }

    public static void Save()
    {
        Data.Save();
    }
}

public class MapData
{
    public List<string> planets = new List<string>();
    public List<string> shipwrecks = new List<string>();
    
    public void Load()
    {
        string json = "{}";
        if (File.Exists(Registry.profile.map_path + "/map_data.json"))
        {
            json = File.ReadAllText(Registry.profile.map_path + "/map_data.json");
        }
        else
        {
            Save();
        }
        JsonUtility.FromJsonOverwrite(json, this);   
    }
        
    public void Save()
    {
        if (!Directory.Exists(Registry.profile.map_path))
        {
            Directory.CreateDirectory(Registry.profile.map_path);
        }
        File.WriteAllText(Registry.profile.map_path + "/map_data.json", JsonUtility.ToJson(this, true));
    }
}
