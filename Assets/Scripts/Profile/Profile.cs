using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Profile
{
    public static string name = "Player";
    public static float health = 4F;
    public static int hearts = 4;
    public static int currency;
    public static string currency_name = "Credit";
    public static string current_galaxy = "Galaxy";
    public static string current_solarsystem = "Solarsystem";
    public static string current_planet = "";
    public static string latest_solarSystem = "";
    public static string latest_galaxy = "";
    public static string current_texturepack = "Default";
    public static string map_path;
    public static string profile_path;
    public static string save_version;
    public static bool gameStart;

    public static int tin_amount;
    public static int gold_amount;
    public static int crystal_amount;
    public static int bronze_amount;
    public static int titan_amount;
    public static int aluminium_amount;
    public static int coal_amount;
    public static int carbon_amount;
    public static int nickel_amount;
    public static int tungsten_amount;
    public static int iron_amount;
    public static int copper_amount;


    public static void load()
    {
        ProfileData data = ProfileSave.load();
        name = data.name;
        health = data.health;
        hearts = data.hearts;
        gameStart = data.gameStart;
        current_galaxy = data.current_galaxy;
        current_solarsystem = data.current_solarsystem;
        latest_galaxy = data.latest_galaxy;
        latest_solarSystem = data.latest_solarSystem;
        tin_amount = data.tin_amount;
        gold_amount = data.gold_amount;
        crystal_amount = data.crystal_amount;
        bronze_amount = data.bronze_amount;
        titan_amount = data.titan_amount;
        aluminium_amount = data.aluminium_amount;
        coal_amount = data.coal_amount;
        carbon_amount = data.carbon_amount;
        nickel_amount = data.nickel_amount;
        tungsten_amount = data.tungsten_amount;
        copper_amount = data.copper_amount;
        iron_amount = data.iron_amount;
        current_texturepack = data.current_texturepack;
        save_version = data.save_version;
        currency = data.currency;
        profile_path = Application.persistentDataPath + "/profiles/" + References.current_profile + "/";
        map_path = profile_path + current_galaxy + "/" + current_solarsystem + "/";
    }

    public static void save()
    {
        ProfileSave.save();
        Ship.Save();
    }

    public static void start()
    {
        Options.load();
        Ship.Load();
        load();
        if (save_version != null)
        {
            if (!save_version.Equals(Application.version))
            {
                SceneManager.LoadScene("SaveCheckscreen");
            }
            else
            {
                save_version = Application.version;
                if (!gameStart)
                {
                    System.Random random = new System.Random();
                    current_galaxy = References.randomNames[random.Next(References.randomNames.Length)] + " " + References.randomNumbersRom[random.Next(References.randomNumbersRom.Length)];
                    current_solarsystem = References.randomNames[random.Next(References.randomNames.Length)] + "-" + random.Next(9999);
                    gameStart = true;
                    save();
                    SceneManager.LoadScene("NewGameScreen");
                }
                else
                {
                    //SceneManager.LoadScene("Galaxyscreen");
                    SceneManager.LoadScene("SpaceMap");
                    save();
                }
            }
        } else
        {
            save_version = Application.version;
            save();
            start();
        }
    }
}
