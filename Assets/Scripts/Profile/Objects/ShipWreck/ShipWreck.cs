using System.IO;
using UnityEngine;

public class ShipWreck
{
    public int index;
    public GameObject main;
    public ShipWreckData Data = new ShipWreckData();
    public ShipWreck(string type, GameObject main)
    {
        Data.type = type;
        this.main = main;
    }
    
    public bool Exists()
    { 
        if(Map.Data.shipwrecks.Count < index + 1)
        {
            return false;
        }
        Data.name = Map.Data.shipwrecks[index];
        return Directory.Exists(Registry.profile.map_path + "/shipwrecks/" + Map.Data.shipwrecks[index] + "/");
    }
    public void Generate()
    {
        System.Random random = new System.Random();
        Map.Load();
        if (Exists()) {
            Load(Data.name);
            Debug.Log("Loaded ShipWreck: " + Data.name);
        }

        if (!Exists())
        {
            Data.name = generateName(random);
            Map.Data.shipwrecks.Add(Data.name);
            Debug.Log("Generated ShipWreck: " + Data.name);
        }
        Map.Save();
    }
    public void Load(string name)
    {
        Data.Load(name);
    }
    public void Save()
    {
        Data.Save();
    }

    private string generateName(System.Random random)
    {
        string genName = Registry.Names.OTHER[random.Next(Registry.Names.OTHER.Count)] + "-" + random.Next(9999);
        if (Map.Data.shipwrecks.Contains(genName))
        {
            return generateName(random);
        }
        return genName;
    }
}
public class ShipWreckData
{
    public string name = "";
    public string type = "ShipWreck-0";
    
    public void Load(string shipwreckName)
    {
        string json = "{}";
        if (File.Exists(Registry.profile.map_path + "/shipwrecks/" + shipwreckName + "/data.json"))
        {
            json = File.ReadAllText(Registry.profile.map_path + "/shipwrecks/" + shipwreckName + "/data.json");
        }
        else
        {
            Save(shipwreckName);
        }
        JsonUtility.FromJsonOverwrite(json, this);   
    }
        
    public void Save(string shipwreckName)
    {
        if (!Directory.Exists(Registry.profile.map_path + "/shipwrecks/" + shipwreckName + "/"))
        {
            Directory.CreateDirectory(Registry.profile.map_path + "/shipwrecks/" + shipwreckName + "/");
        }
        File.WriteAllText(Registry.profile.map_path + "/shipwrecks/" + shipwreckName + "/data.json", JsonUtility.ToJson(this, true));
    }

    public void Save()
    {
        Save(name);
    }
}