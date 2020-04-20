using System;
using System.Collections.Generic;

[System.Serializable]
public class ProfileData
{
    public string name;
    public float health;
    public int hearts;
    public string current_galaxy;
    public string current_solarsystem;
    public string latest_solarSystem;
    public string latest_galaxy;
    public string current_texturepack;
    public string save_version;
    public bool gameStart;
    public int tin_amount;
    public int gold_amount;
    public int crystal_amount;
    public int bronze_amount;
    public int titan_amount;
    public int aluminium_amount;
    public int coal_amount;
    public int carbon_amount;
    public int nickel_amount;
    public int tungsten_amount;
    public int copper_amount;
    public int iron_amount;
    public int currency;
    public ProfileData()
    {
        name = Profile.name;
        health = Profile.health;
        hearts = Profile.hearts;
        current_galaxy = Profile.current_galaxy;
        current_solarsystem = Profile.current_solarsystem;
        gameStart = Profile.gameStart;
        latest_solarSystem = Profile.latest_solarSystem;
        latest_galaxy = Profile.latest_galaxy;
        tin_amount = Profile.tin_amount;
        gold_amount = Profile.gold_amount;
        crystal_amount = Profile.crystal_amount;
        bronze_amount = Profile.bronze_amount;
        titan_amount = Profile.titan_amount;
        aluminium_amount = Profile.aluminium_amount;
        coal_amount = Profile.coal_amount;
        carbon_amount = Profile.carbon_amount;
        nickel_amount = Profile.nickel_amount;
        tungsten_amount = Profile.tungsten_amount;
        iron_amount = Profile.iron_amount;
        copper_amount = Profile.copper_amount;
        current_texturepack = Profile.current_texturepack;
        save_version = Profile.save_version;
        currency = Profile.currency;
    }
}