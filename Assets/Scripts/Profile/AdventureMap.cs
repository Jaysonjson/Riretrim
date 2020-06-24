using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System;
public class AdventureMap
{
    public Dictionary<string, Galaxy> galaxies = new Dictionary<string, Galaxy>();

    public void Load()
    {
        string json = "{}";
        if (File.Exists(Registry.profile.profile_path + "/adventure.json"))
        {
            json = File.ReadAllText(Registry.profile.profile_path + "/adventure.json");
        }
        else
        {
            Save();
        }
        //JsonUtility.FromJsonOverwrite(json, this);
        Registry.adventureMap = JsonConvert.DeserializeObject<AdventureMap>(json);
    }

    public void Save()
    {
        if (!Directory.Exists(Registry.profile.profile_path + "/"))
        {
            Directory.CreateDirectory(Registry.profile.profile_path + "/");
        }
        //File.WriteAllText(Application.persistentDataPath + "/profiles/" + profileName + "/data.json", JsonUtility.ToJson(this, true));
        File.WriteAllText(Registry.profile.profile_path + "/adventure.json", JsonConvert.SerializeObject(this, Formatting.Indented));
    }
}