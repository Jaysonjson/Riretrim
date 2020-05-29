using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Profile
{
    public ProfileData Data = new ProfileData();
    public Ship Ship = new Ship();
    public string map_path;
    public string profile_path;

    public string mod_path;
    public void Load()
    {
        Data.Load();
        profile_path = Application.persistentDataPath + "/profiles/" + References.current_profile + "/";
        map_path = profile_path + Data.current_galaxy + "/" + Data.current_solarsystem + "/";
        mod_path = Application.persistentDataPath + "/mods/";
    }

    public void Save()
    {
        Ship.Save();
        Data.Save();
    }

    public void start()
    {
        if(!Directory.Exists(mod_path)) {
            Directory.CreateDirectory(mod_path);
            Directory.CreateDirectory(mod_path + "/ships/");
        }
        Options.Load();
        Load();
        Ship.Load();
        Data.save_version = Application.version;
        if (Data.save_version != null)
        {
            if (!Data.save_version.Equals(Application.version))
            {
                SceneManager.LoadScene("SaveCheckscreen");
            }
            else
            {
                Data.save_version = Application.version;
                if (!Data.gameStart)
                {
                    System.Random random = new System.Random();
                    Data.current_galaxy = Registry.Names.GALAXY[random.Next(Registry.Names.GALAXY.Count)] + "-" + Registry.Names.SUFFIX[random.Next(Registry.Names.SUFFIX.Count)];
                    Data.current_solarsystem = Registry.Names.SOLARSYSTEM[random.Next(Registry.Names.SOLARSYSTEM.Count)] + "-" + random.Next(9999);
                    Data.gameStart = true;
                    Save();
                    SceneManager.LoadScene("NewGameScreen");
                }
                else
                {
                    //SceneManager.LoadScene("Galaxyscreen");
                    SceneManager.LoadScene("SpaceMap");
                    Save();
                }
            }
        } else
        {
            Data.save_version = Application.version;
            Save();
            start();
        }
    }
}

public class ProfileData
{
    public string name = "Player";
    public float health = 4F;
    public int hearts = 4;
    public int currency;
    public string currency_name = "Credit";
    public string current_galaxy = "Galaxy";
    public string current_solarsystem = "Solarsystem";
    public string current_planet = "";
    public string latest_solarSystem = "";
    public string latest_galaxy = "";
    public string save_version;
    public bool gameStart;

    public int tin_amount = 0;
    public int gold_amount;
    public int crystal_amount;
    public int bronze_amount;
    public int titan_amount;
    public int aluminium_amount;
    public int coal_amount;
    public int carbon_amount;
    public int nickel_amount;
    public int tungsten_amount;
    public int iron_amount;
    public int copper_amount;

    public float ship_xp;

    public void Load()
    {
        string json = "{}";
        if (File.Exists(Application.persistentDataPath + "/profiles/" + References.current_profile + "/data.json"))
        {
            json = File.ReadAllText(Application.persistentDataPath + "/profiles/" + References.current_profile + "/data.json");
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
        File.WriteAllText(Application.persistentDataPath + "/profiles/" + References.current_profile + "/data.json", JsonUtility.ToJson(this, true));
    }
}
