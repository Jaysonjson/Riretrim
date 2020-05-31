using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Galaxy
{
    public static GalaxyData Data = new GalaxyData();
    public static void Load()
    {
        Data.Load();
    }

    public static void Save()
    {
        Data.Save();
    }
}

public class GalaxyData
{
    public List<string> stars = new List<string>();
    
    public void Load()
    {
        string json = "{}";
        if (File.Exists(Application.persistentDataPath + "/profiles/" + Registry.profile.Data.profileName + "/" + Registry.profile.Data.current_galaxy + "/galaxy_data.json"))
        {
            json = File.ReadAllText(Application.persistentDataPath + "/profiles/" + Registry.profile.Data.profileName + "/" + Registry.profile.Data.current_galaxy + "/galaxy_data.json");
        }
        else
        {
            Save();
        }
        JsonUtility.FromJsonOverwrite(json, this);   
    }
        
    public void Save()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/profiles/" + Registry.profile.Data.profileName + "/" + Registry.profile.Data.current_galaxy))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/profiles/" + Registry.profile.Data.profileName + "/" + Registry.profile.Data.current_galaxy);
        }
        File.WriteAllText(Application.persistentDataPath + "/profiles/" + Registry.profile.Data.profileName + "/" + Registry.profile.Data.current_galaxy + "/galaxy_data.json", JsonUtility.ToJson(this, true));
    }
}