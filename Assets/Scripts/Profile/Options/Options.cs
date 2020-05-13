using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options
{
    public static OptionData Data = new OptionData();
    public static void Load()
    {
        Data.Load();
    }

    public static void Save()
    {
        Data.Save();
    }
}

public class OptionData
{
    public float AsteroidDespawnDistance = 45f;
    public bool AsteroidShadows = false;
    public bool ParticleSystems = true;
    public bool ObjectShadows = true;
    public bool Lights = true;
    public bool ShowFPS = false;
    public string Language = "English";
    public string Texturepack = "Default";
    public int HUDScale = 1920;
    public MiniMapHUD MiniMapHud = MiniMapHUD.SQUARE;
    public void Load()
    {
        string json = "{}";
        if (File.Exists(Application.persistentDataPath + "/settings.json"))
        {
            json = File.ReadAllText(Application.persistentDataPath + "/settings.json");
        }
        else
        {
            Save();
        }
        JsonUtility.FromJsonOverwrite(json, this);   
    }
        
    public void Save()
    {
        File.WriteAllText(Application.persistentDataPath + "/settings.json", JsonUtility.ToJson(this, true));
    }
}

public enum MiniMapHUD
{
    CIRCLE, SQUARE
}