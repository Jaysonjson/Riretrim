using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
public class Star
{
    public StarData Data = new StarData();
    [JsonIgnore]
    public Galaxy galaxy;
    [JsonIgnore]
    private int nameTries = 0;

    public Star(Galaxy galaxy)
    {
        this.galaxy = galaxy;
    }

    public void Generate(MapGeneration map)
    {
        System.Random random = new System.Random();
        Data.name = generateName(random);
        map.text = "Generating Star: " + Data.name;
        Data.solarSystem = Data.name;
        Data.asteroid_count = random.Next(MapOptions.Data.AsteroidMinSpawnAmount, MapOptions.Data.AsteroidMaxSpawnAmount);
        int planet_count = random.Next(MapOptions.Data.PlanetMaxAmount / 4);
        Data.enemy_count = random.Next(10, 35);
        int shipwreck_count = random.Next(10);
        map.maxTasks += planet_count + shipwreck_count;
        Data.sunScale = (float)(random.Next(15, 35) + random.NextDouble());
        if (random.Next(1) == 1)
        {
            Data.secondSun = true;
        }
        if (random.Next(10) == 1)
        {
            planet_count = random.Next(MapOptions.Data.PlanetMaxAmount / 2);
        }
        if (random.Next(25) == 1)
        {
            planet_count = random.Next(MapOptions.Data.PlanetMaxAmount);
        }
        Data.position_x = (float)(random.Next(-5, 5) + random.NextDouble());
        Data.position_y = (float)(random.Next(-4, 4) + random.NextDouble());
        Data.speed = (float)random.Next(1, 6) / 10 + (float)random.Next(1, 9) / 100;
        if (random.Next(3) == 1)
        {
            Data.color[0] = (byte)(random.Next(250));
            Data.color[1] = (byte)(random.Next(250));
            Data.color[2] = (byte)(random.Next(250));
        }
        map.currentTask++;
        //Debug.Log(Data.name);
        for (int i = 0; i < planet_count; i++)
        {
            Planet planet = new Planet(this);
            planet.Generate(map);
            if (!Data.planets.ContainsKey(planet.Data.name))
            {
                Data.planets.Add(planet.Data.name, planet);
            }
        }

        for (int i = 0; i < shipwreck_count; i++)
        {
            ShipWreck shipWreck = new ShipWreck(this);
            shipWreck.Generate(map);
            if (!Data.shipWrecks.ContainsKey(shipWreck.Data.name))
            {
                Data.shipWrecks.Add(shipWreck.Data.name, shipWreck);
            }
        }
    }

    private string generateName(System.Random random)
    {
        nameTries++;
        Thread.Sleep(13);
        string genName = Registry.Names.SOLARSYSTEM[new System.Random().Next(Registry.Names.SOLARSYSTEM.Count)] + "-" + new System.Random().Next(9999);
        if (nameTries < 75)
        {
            if (galaxy.Data.stars.ContainsKey(genName))
            {
                return generateName(random);
            }
        }
        return genName;
    }
}
public class StarData
{
    public string solarSystem = "";
    public string name = "";
    public int asteroid_count = 0;
    public float position_x = 0;
    public float position_y = 0;
    public float speed = 0;
    public int enemy_count = 75;
    public bool secondSun = false;
    public bool visited = false;
    public float sunScale = 1;
    public JsonDateTime visitTime = new JsonDateTime();
    public byte[] color = { 253, 184, 19 };
    public Dictionary<string, Planet> planets = new Dictionary<string, Planet>();
    public Dictionary<string, ShipWreck> shipWrecks = new Dictionary<string, ShipWreck>();
}
