﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Moon
{
    public string name;
    public float scale;
    public string planet;
    public int index;
    public Planet planetObject;
    public GameObject moon;

    public Moon(string PlanetParent, Planet PlanetObject)
    {
        planet = PlanetParent;
        planetObject = PlanetObject;
    }
    public Moon(GameObject Moon, string PlanetParent, Planet PlanetObject)
    {
        planet = PlanetParent;
        planetObject = PlanetObject;
        moon = Moon;
    }

    public Moon()
    {

    }
    public bool Exists()
    {
        if (planetObject.moons.Count < index + 1)
        {
            return false;
        }
        name = planetObject.moons[index];
        return Directory.Exists(Profile.map_path + "/planets/" + planetObject.pname + "/moons/" + planetObject.moons[index]);
    }
    public void Generate()
    {
        System.Random random = new System.Random();
        //planetObject.load(planetObject.index);
        if (Exists())
        {
            LoadUsingName(name);
            Debug.Log("Loaded Moon: " + name + "; from Planet: " + planetObject.pname);
        }
        if (!Exists())
        {
            name = References.randomNames[random.Next(References.randomNames.Length)] + "-" + random.Next(9999);
            scale = (planetObject.planetMain.transform.localScale.x / (float)(random.Next(3,6) + random.NextDouble())) / 7.5f;
            Debug.Log("Generated Moon: " + name + "; from Planet: " + planetObject.pname);
            planetObject.moons.Add(name);
            planetObject.save(planetObject.index);
        }
        moon.name = name;
        moon.transform.localScale = new Vector3(scale,scale,1);
        //moon.GetComponentInParent<TextMeshProUGUI>().text = name;
        //moon.transform.FindChild("MoonDummyText").GetComponent<TextMeshProUGUI>().text = name;
    }

    public void LoadUsingName(string Name)
    {
        LoadUsingName(planet, Name);
    }

    public void LoadUsingName(string PlanetParent, string Name)
    {
        MoonData data = MoonSave.LoadUsingName(PlanetParent, Name);
        scale = data.scale;
    }

    public void SaveAsMoon()
    {
        MoonSave.SaveNewMoon(planet, this);
    }
}
