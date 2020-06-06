using System.IO;
using UnityEngine;

public class MapOptions
{
    public static MapOptionData Data = new MapOptionData();
    public static void Load()
    {
        Data.Load();
    }

    public static void Save()
    {
        Data.Save();
    }
}

public class MapOptionData
{
    public int AsteroidMaxSpawnAmount = 50;
    public int AsteroidMinSpawnAmount = 5;
    public int PlanetMaxAmount = 25;
    public bool ShipWrecks = true;
    public bool Moons = true;
    
    public void Load()
    {
        string json = "{}";
        if (File.Exists(Registry.profile.profile_path + "map_settings.json"))
        {
            json = File.ReadAllText(Registry.profile.profile_path + "map_settings.json");
        }
        else
        {
            Save();
        }
        JsonUtility.FromJsonOverwrite(json, this);   
    }
        
    public void Save()
    {
        if (!Directory.Exists( Registry.profile.profile_path))
        {
            Directory.CreateDirectory(Registry.profile.profile_path);
        }
        File.WriteAllText( Registry.profile.profile_path + "map_settings.json", JsonUtility.ToJson(this, true));
    }
}