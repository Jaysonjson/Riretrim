using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
public class Profile
{
    public ProfileData Data = new ProfileData();
    public Ship Ship = new Ship();
    public string map_path;
    public string profile_path = "";
    public string mod_path;

    public Profile(string name)
    {
        profile_path = Application.persistentDataPath + "/profiles/" + name + "/";
    }

    public Profile()
    {

    }

    public void SetUp(string name)
    {
        Data.profileName = name;
        profile_path = Application.persistentDataPath + "/profiles/" + Data.profileName + "/";
    }

    public void Load()
    {
        Data.Load();
        profile_path = Application.persistentDataPath + "/profiles/" + Data.profileName + "/";
        map_path = profile_path + Data.current_galaxy + "/" + Data.current_solarsystem + "/";
        mod_path = Application.persistentDataPath + "/mods/";
    }

    public void Save()
    {
        Data.lastSaveDate = Data.lastSaveDate.convertToJsonDateTime(DateTime.Now);
        Ship.Save();
        Data.Save();
    }

    public void start()
    {
        Options.Load();
        Load();
        Ship.Load();
        Registry.adventureMap.Load();
        if (!Directory.Exists(mod_path))
        {
            Directory.CreateDirectory(mod_path);
            Directory.CreateDirectory(mod_path + "/ships/");
        }
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
                if (!Data.gameStartOFE)
                {
                    System.Random random = new System.Random();
                    //Data.current_galaxy = Registry.Names.GALAXY[random.Next(Registry.Names.GALAXY.Count)] + "-" + Registry.Names.SUFFIX[random.Next(Registry.Names.SUFFIX.Count)];
                    //Data.current_solarsystem = Registry.Names.SOLARSYSTEM[random.Next(Registry.Names.SOLARSYSTEM.Count)] + "-" + random.Next(9999);
                    Data.gameStartOFE = true;
                    Save();
                    SceneManager.LoadScene("NewGameScreen");
                }
                else
                {
                    //SceneManager.LoadScene("Galaxyscreen");
                    SceneManager.LoadScene("SpaceMap");
                }
            }
        }
        else
        {
            Data.save_version = Application.version;
            Save();
            start();
        }
    }
}

public class ProfileData
{
    public string profileName = "main";
    public string name = "Player";
    public float health = 4F;
    public int hearts = 4;
    public int currency = 0;
    public string currency_name = "Credit";
    public string current_galaxy = "Galaxy";
    public string current_solarsystem = "Solarsystem";
    public string current_planet = "";
    public string latest_solarSystem = "";
    public string latest_galaxy = "";
    public string save_version = "";
    public bool gameStartOFE = false;
    public bool current = false;
    public JsonDateTime creationDate = new JsonDateTime();
    public JsonDateTime lastSaveDate = new JsonDateTime();
    public int tin_amount = 4;
    public int gold_amount = 0;
    public int crystal_amount = 0;
    public int bronze_amount = 0;
    public int titan_amount = 0;
    public int aluminium_amount = 25;
    public int coal_amount = 30;
    public int carbon_amount = 0;
    public int nickel_amount = 0;
    public int tungsten_amount = 0;
    public int iron_amount = 7;
    public int copper_amount = 4;

    public float ship_xp;

    public bool Load(string path, Profile profile)
    {
        string json = "{}";
        Debug.Log("Loading Profile");
        if (File.Exists(path + "/data.json"))
        {
            json = File.ReadAllText(path + "/data.json");
        }
        else
        {
            Debug.Log("Couldn't load Profile, saving... (" + path + ")");
            Save();
            return false;
        }
        //JsonUtility.FromJsonOverwrite(json, this);
        profile.Data = JsonConvert.DeserializeObject<ProfileData>(json);
        Debug.Log("Loaded Profile: " + profile.Data.profileName);
        return true;
    }

    public void Load(string path)
    {
        Load(path, Registry.profile);
    }

    public void Load()
    {
        Load(Registry.profile.profile_path);
    }

    public void Save()
    {
        if (!Directory.Exists(Registry.profile.profile_path + "/"))
        {
            Directory.CreateDirectory(Registry.profile.profile_path + "/");
        }
        //File.WriteAllText(Application.persistentDataPath + "/profiles/" + profileName + "/data.json", JsonUtility.ToJson(this, true));
        File.WriteAllText(Registry.profile.profile_path + "/data.json", JsonConvert.SerializeObject(this, Formatting.Indented));
    }
}
