
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.Experimental.Rendering.Universal;
using System;
using Newtonsoft.Json;

public class Planet
{
    [JsonIgnore]
    float dist;
    public PlanetData Data = new PlanetData();
    [JsonIgnore]
    private int nameTries = 0;
    [JsonIgnore]
    public Star star;

    public Planet(Star star)
    {
        this.star = star;
    }

    public void Generate(MapGeneration map)
    {
        map.currentTask++;
        System.Random random = new System.Random();
        Data.name = generateName(random);
        map.text = "Generating Planet: " + Data.name + "...";
        Data.id = random.Next(99999999);
        int moonAmount = 0;
        Data.orbit.speededOrbit = true;
        if (random.Next(3) == 1)
        {
            moonAmount = random.Next(3);
            if (random.Next(3) == 1)
            {
                moonAmount = random.Next(5);
            }
            if (random.Next(6) == 1)
            {
                moonAmount = random.Next(10);
            }
        }

        int spaceStationAmount = random.Next(2);

        if (random.Next(3) == 1)
        {
            spaceStationAmount = random.Next(2);
        }
        //Data.position_x = (float)(random.Next(-200, 200) + 1.25 + random.NextDouble());
        Array types = Enum.GetValues(typeof(PlanetType));
        Data.type = (PlanetType)types.GetValue(random.Next(types.Length));
        //dist = Vector2.Distance(sun.transform.position, new Vector2(Data.position_x, Data.position_y));
        Data.scale = (float)(5 + random.NextDouble());
        /*if (dist < 25) { Data.type = PlanetType.LAVA; }
        if (dist > 35) { Data.type = PlanetType.ROCKY; }
        if (dist > 55) { Data.type = PlanetType.EARTHLIKE; }
        if (dist > 90) { Data.type = PlanetType.GAS; }
        if (dist > 135) { Data.type = PlanetType.EXOTIC; }
        if (dist > 165) { Data.type = PlanetType.ICE; }
        */
        if (Data.type == PlanetType.EXOTIC)
        {
            Data.position.x = (float)(random.Next(115, 175) + random.NextDouble());
            Data.color[0] = 255;
            Data.color[1] = (byte)(random.Next(135));
            Data.color[2] = 255;
            Data.scale = (float)(random.Next(5, 10) + random.NextDouble());
            Data.spriteNumber = random.Next(Registry.INSTANCE.planetSprites.exoticSprites.Length);
            Data.materials.Add(Materials.ALUMINIUM);
            if (random.Next(3) == 1)
            {
                Data.materials.Add(Materials.TUNGSTEN);
            }
            if (random.Next(10) == 1)
            {
                Data.materials.Add(Materials.CRYSTAL);
            }
            if (map != null)
            {
                map.planetImageUpdate = true;
                map.planetImageType = PlanetType.EXOTIC;
                map.planetImageID = Data.spriteNumber;
            }
        }
        if (Data.type == PlanetType.EARTHLIKE)
        {
            Data.position.x = (float)(random.Next(75, 100) + random.NextDouble());
            Data.color[0] = 0;
            Data.color[1] = (byte)(random.Next(135));
            Data.color[2] = 255;
            Data.scale = (float)(random.Next(3, 7) + random.NextDouble());
            Data.spriteNumber = random.Next(Registry.INSTANCE.planetSprites.earthLikeSprites.Length);
            Data.materials.Add(Materials.IRON);
            if (random.Next(3) == 1)
            {
                Data.materials.Add(Materials.TUNGSTEN);
            }
            if (random.Next(5) == 1)
            {
                Data.materials.Add(Materials.GOLD);
            }
            if (map != null)
            {
                map.planetImageUpdate = true;
                map.planetImageType = PlanetType.EARTHLIKE;
                map.planetImageID = Data.spriteNumber;
            }
        }
        if (Data.type == PlanetType.LAVA)
        {
            Data.position.x = (float)(random.Next(20, 50) + random.NextDouble());
            Data.color[0] = (byte)(random.Next(150, 255));
            Data.color[1] = (byte)(random.Next(0, 50));
            Data.color[2] = (byte)(random.Next(0, 50));
            Data.scale = (float)(random.Next(2, 5) + random.NextDouble());
            Data.spriteNumber = random.Next(Registry.INSTANCE.planetSprites.lavaSprites.Length);
            Data.materials.Add(Materials.COAL);
            if (random.Next(3) == 1)
            {
                Data.materials.Add(Materials.GOLD);
            }
            if (random.Next(5) == 1)
            {
                Data.materials.Add(Materials.TITAN);
            }
            if (map != null)
            {
                map.planetImageUpdate = true;
                map.planetImageType = PlanetType.LAVA;
                map.planetImageID = Data.spriteNumber;
            }
        }
        if (Data.type == PlanetType.ROCKY)
        {
            Data.position.x = (float)(random.Next(55, 70) + random.NextDouble());
            Data.color[0] = (byte)(random.Next(0, 255));
            Data.color[1] = (byte)(random.Next(0, 106));
            Data.color[2] = 0;
            Data.scale = (float)(random.Next(2, 7) + random.NextDouble());
            Data.spriteNumber = random.Next(Registry.INSTANCE.planetSprites.rockySprites.Length);
            Data.materials.Add(Materials.IRON);
            if (random.Next(3) == 1)
            {
                Data.materials.Add(Materials.COPPER);
            }
            if (random.Next(5) == 1)
            {
                Data.materials.Add(Materials.TIN);
            }
            if (map != null)
            {
                map.planetImageUpdate = true;
                map.planetImageType = PlanetType.ROCKY;
                map.planetImageID = Data.spriteNumber;
            }
        }
        if (Data.type == PlanetType.GAS)
        {
            Data.position.x = (float)(random.Next(110, 150) + random.NextDouble());
            Data.color[0] = (byte)(random.Next(255));
            Data.color[1] = (byte)(random.Next(255));
            Data.color[2] = (byte)(random.Next(255));
            Data.scale = (float)(random.Next(7, 15) + random.NextDouble());
            Data.spriteNumber = random.Next(Registry.INSTANCE.planetSprites.gasSprites.Length);
            Data.materials.Add(Materials.COPPER);
            if (random.Next(3) == 1)
            {
                Data.materials.Add(Materials.NICKEL);
            }
            if (random.Next(5) == 1)
            {
                Data.materials.Add(Materials.TIN);
            }
            if (map != null)
            {
                map.planetImageUpdate = true;
                map.planetImageType = PlanetType.GAS;
                map.planetImageID = Data.spriteNumber;
            }
        }
        if (Data.type == PlanetType.ICE)
        {
            Data.position.x = (float)(random.Next(200, 250) + random.NextDouble());
            Data.color[0] = (byte)(random.Next(200, 255));
            Data.color[1] = (byte)(random.Next(135, 255));
            Data.color[2] = (byte)(random.Next(200, 255));
            Data.scale = (float)(random.Next(4, 14) + random.NextDouble());
            Data.spriteNumber = random.Next(Registry.INSTANCE.planetSprites.iceSprites.Length);
            Data.materials.Add(Materials.NICKEL);
            if (random.Next(3) == 1)
            {
                Data.materials.Add(Materials.COPPER);
            }
            if (random.Next(5) == 1)
            {
                Data.materials.Add(Materials.TIN);
            }
            if (map != null)
            {
                map.planetImageUpdate = true;
                map.planetImageType = PlanetType.ICE;
                map.planetImageID = Data.spriteNumber;
            }
        }
        Data.orbit.speed = (float)(random.NextDouble()) / 5;

        for (int i = 0; i < spaceStationAmount; i++)
        {
            SpaceStation station = new SpaceStation();
            station.Generate(map, this);
            if (!Data.spaceStations.ContainsKey(station.Data.name))
            {
                Data.spaceStations.Add(station.Data.name, station);
            }
        }

        if (MapOptions.Data.Moons)
            for (int i = 0; i < moonAmount; i++)
            {
                Moon moon = new Moon();
                moon.Generate(map, this);
                if (!Data.moons.ContainsKey(moon.Data.name))
                {
                    Data.moons.Add(moon.Data.name, moon);
                }
            }
    }

    private string generateName(System.Random random)
    {
        nameTries++;
        Thread.Sleep(13);
        string genName = Registry.Names.PLANET[new System.Random().Next(Registry.Names.PLANET.Count)] + "-" + new System.Random().Next(9999);
        if (nameTries < 1500)
        {
            if (star.Data.planets.ContainsKey(genName))
            {
                return generateName(random);
            }
        }
        return genName;
    }
}





public class PlanetData
{
    public string name = "Unknown";
    public int id = 0;
    public Position position = new Position();
    public List<Materials> materials = new List<Materials>();
    public byte[] color = { 255, 255, 255 };
    public PlanetType type = PlanetType.LAVA;
    public float scale = 1;
    public OrbitData orbit = new OrbitData();
    public int spriteNumber = 0;
    public Dictionary<string, Moon> moons = new Dictionary<string, Moon>();
    public Dictionary<string, SpaceStation> spaceStations = new Dictionary<string, SpaceStation>();
    public Dictionary<string, MiningDrill> miningDrills = new Dictionary<string, MiningDrill>();
}
