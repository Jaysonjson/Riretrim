using UnityEngine;
using System.IO;
public class ModdedShipData {
    public string sprite = "";

    public string name = "";
    public int xp = 0;
    public int price = 0;

    public void Load(string file)
    {
        string json = "{}";
        if (File.Exists(file))
        {
            json = File.ReadAllText(file);
        } else {
            Debug.Log("Couldn't load " + file);
        }
        JsonUtility.FromJsonOverwrite(json, this);   
    }
}