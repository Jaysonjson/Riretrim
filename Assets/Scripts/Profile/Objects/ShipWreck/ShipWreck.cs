using System.IO;
using UnityEngine;

public class ShipWreck
{
    public int index;
    public string name;
    public string type;
    public GameObject main;
    
    public ShipWreck(string type, GameObject main)
    {
        this.type = type;
        this.main = main;
    }
    
    public bool Exists()
    { 
        if(Map.Data.shipwrecks.Count < index + 1)
        {
            return false;
        }
        name = Map.Data.shipwrecks[index];
        return Directory.Exists(Registry.profile.map_path + "/shipwrecks/" + Map.Data.shipwrecks[index] + "/");
    }
    public void Generate()
    {
        System.Random random = new System.Random();
        Map.Load();
        if (Exists()) {
            LoadUsingName(name);
            Debug.Log("Loaded ShipWreck: " + name);
        }

        if (!Exists())
        {
            name = References.randomNames[random.Next(References.randomNames.Length)] + "-" + random.Next(9999);
            Map.Data.shipwrecks.Add(name);
            Debug.Log("Generated ShipWreck: " + name);
        }
        Map.Save();
    }
    public void LoadUsingName(string name)
    {
        ShipWreckData data = ShipWreckSave.LoadUsingName(name);
        name = data.name;
    }
    public void SaveAsShipWreck()
    {
        ShipWreckSave.SaveNewShipWreck(this);
    }
}
