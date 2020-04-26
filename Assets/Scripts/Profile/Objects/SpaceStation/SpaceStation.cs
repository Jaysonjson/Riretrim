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
        if (planetObject.spaceStations.Count < index + 1)
        {
            return false;
        }
        name = planetObject.spaceStations[index];
        return Directory.Exists(Profile.map_path + "/planets/" + planetObject.pname + "/spacestations/" + planetObject.spaceStations[index]);
    }
    public void Generate()
    {
        System.Random random = new System.Random();
        if (Exists())
        {
            LoadUsingName(name);
            Debug.Log("Loaded Space Station: " + name + "; from Planet: " + planetObject.pname);
        }
        if (!Exists())
        {
            name = References.randomNames[random.Next(References.randomNames.Length)] + "-" + random.Next(9999);
            scale = (planetObject.planetMain.transform.localScale.x / (float)(random.Next(3,6) + random.NextDouble())) / 5.5f;
            Debug.Log("Generated Space Station: " + name + "; from Planet: " + planetObject.pname);
            planetObject.spaceStations.Add(name);
            planetObject.save(planetObject.index);
        }
        spaceStation.name = name;
       // spaceStation.transform.localScale = new Vector3(scale,scale,1);
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
