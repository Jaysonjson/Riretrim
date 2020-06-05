using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpaceStation
{
    public string name;
    public float scale;
    public string planet;
    public int index;
    public Planet planetObject;
    public GameObject spaceStation;
    private int nameTries = 0;

    public SpaceStation(string PlanetParent, Planet PlanetObject)
    {
        planet = PlanetParent;
        planetObject = PlanetObject;
    }
    public SpaceStation(GameObject SpaceStation, string PlanetParent, Planet PlanetObject)
    {
        planet = PlanetParent;
        planetObject = PlanetObject;
        spaceStation = SpaceStation;
    }

    public SpaceStation()
    {

    }
    public bool Exists()
    {
        if (planetObject.Data.spaceStations.Count < index + 1)
        {
            return false;
        }
        name = planetObject.Data.spaceStations[index];
        return Directory.Exists(Registry.profile.map_path + "/planets/" + planetObject.Data.name + "/spacestations/" + planetObject.Data.spaceStations[index]);
    }
    public void Generate()
    {
        System.Random random = new System.Random();
        if (Exists())
        {
            LoadUsingName(name);
            Debug.Log("Loaded Space Station: " + name + "; from Planet: " + planetObject.Data.name);
        }
        if (!Exists())
        {
            name = generateName(random);
            scale = (planetObject.planetMain.transform.localScale.x / (float)(random.Next(3, 6) + random.NextDouble())) / 5.5f;
            Debug.Log("Generated Space Station: " + name + "; from Planet: " + planetObject.Data.name);
            planetObject.Data.spaceStations.Add(name);
            planetObject.Data.Save();
        }
        spaceStation.name = name;
        spaceStation.transform.localScale = new Vector3((scale / planetObject.Data.scale) * 2, (scale / planetObject.Data.scale) * 2, 1);
    }

    private string generateName(System.Random random)
    {
        nameTries++;
        string genName = Registry.Names.SPACESTATION[random.Next(Registry.Names.SPACESTATION.Count)] + "-" + random.Next(9999);
        if (nameTries < 75)
        {
            if (planetObject.Data.spaceStations.Contains(genName))
            {
                return generateName(random);
            }
        }
        return genName;
    }

    public void LoadUsingName(string Name)
    {
        LoadUsingName(planet, Name);
    }

    public void LoadUsingName(string PlanetParent, string Name)
    {
        SpaceStationData data = SpaceStationSave.LoadUsingName(PlanetParent, Name);
        scale = data.scale;
    }

    public void SaveAsSpaceStation()
    {
        SpaceStationSave.SaveNewSpaceStation(planet, this);
    }
}
