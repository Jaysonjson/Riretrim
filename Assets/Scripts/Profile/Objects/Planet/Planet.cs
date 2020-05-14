using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.Experimental.Rendering.Universal;
using System;
using UnityEngine.SceneManagement;

public class Planet
{
    public string[] names = {"Dix","Apol","Zert","Kepler","Keygrocarro","Uphocarro","Bunrao","Vogov","Iruta","Ouwei","Vaditera","Phucetis"};
    public int index;
    public int drillAmount = 0;
    public GameObject planetBody;
    public GameObject miniMap;
    public GameObject planetMain;
    public GameObject[] lights;
    public GameObject[] athmospheres;
    public GameObject[] text;
    public GameObject sun;
    public GameObject moonDummy;
    public GameObject drillDummy;
    public GameObject spaceStationDummy;
    public TextMeshPro informationText;
    float dist;
    public PlanetData Data = new PlanetData();
    public string getName()
    {
        return this.Data.name;
    }

    public Planet(GameObject[] text, GameObject planetBody, GameObject planetMain, GameObject[] lights, GameObject[] athmospheres, GameObject sun, GameObject miniMap, GameObject moonDummy, GameObject drillDummy, GameObject spaceStationDummy, TextMeshPro informationText)
    {
        this.text = text;
        this.planetBody = planetBody;
        this.planetMain = planetMain;
        this.lights = lights;
        this.athmospheres = athmospheres;
        this.sun = sun;
        this.miniMap = miniMap;
        this.moonDummy = moonDummy;
        this.drillDummy = drillDummy;
        this.spaceStationDummy = spaceStationDummy;
        this.informationText = informationText;
    }
    public Planet()
    {

    }
    public bool Exists()
    {
        if(Map.Data.planets.Count < index + 1)
        {
            return false;
        }
        Data.name = Map.Data.planets[index];
        return Directory.Exists(Registry.profile.map_path + "/planets/" + Map.Data.planets[index] + "/");
    }

    public void Generate()
    {
        Map.Load();
        System.Random random = new System.Random();
        if (Exists()) {
            Load(Planets.GetPlanet(index).Data.name);
            Debug.Log("Loaded Planet: " + Data.name);
        }
        if (!Exists())
        {
            if(planetMain == null) {return;}
            planetMain.GetComponent<Orbit>().speed = random.Next(120, 500);
            Data.name = names[random.Next(names.Length)] + "-" + random.Next(9999);
            Data.id = random.Next(99999999);
            Data.moonAmount = random.Next(4);
            if (random.Next(3) == 1)
            {
                Data.moonAmount = random.Next(3);
                if(random.Next(3) == 1)
                {
                    Data.moonAmount = random.Next(5);
                }
                if (random.Next(6) == 1)
                {
                    Data.moonAmount = random.Next(10);
                }
            }
            
            Data.spaceStationAmount = random.Next(2);

            if (random.Next(3) == 1)
            {
                Data.spaceStationAmount = random.Next(2);
            }
            Data.position_x = (float)(random.Next(-200, 200) + 1.25 + random.NextDouble());
            Array types = Enum.GetValues(typeof(PlanetType));
            Data.type = (PlanetType)types.GetValue(random.Next(types.Length));
            dist = Vector2.Distance(sun.transform.position, new Vector2(Data.position_x, Data.position_y));
            Data.scale = (float)( 5 + random.NextDouble());
            if (dist < 25){Data.type = PlanetType.LAVA;}
            if (dist > 35){Data.type = PlanetType.ROCKY;}
            if (dist > 55){Data.type = PlanetType.EARTHLIKE;}
            if (dist > 90){Data.type = PlanetType.GAS;}
            if (dist > 135){Data.type = PlanetType.EXOTIC;}
            if (dist > 165){Data.type = PlanetType.ICE;}

            if (Data.type == PlanetType.EXOTIC)
            {
                Data.color[0] = 255;
                Data.color[1] = (byte)(random.Next(135));
                Data.color[2] = 255;
                Data.scale = (float)(random.Next(5,10) + random.NextDouble());
                Data.spriteNumber = random.Next(Planets.exoticSprites.Length);
                Data.materials.Add(Materials.ALUMINIUM);
                if (random.Next(3) == 1)
                {
                    Data.materials.Add(Materials.TUNGSTEN);
                }
                if (random.Next(10) == 1)
                {
                    Data.materials.Add(Materials.CRYSTAL);
                }
            }
            if (Data.type == PlanetType.EARTHLIKE)
            {
                Data.color[0] = 0;
                Data.color[1] = (byte)(random.Next(135));
                Data.color[2] = 255;
                Data.scale = (float)(random.Next(3, 7) + random.NextDouble());
                Data.spriteNumber = random.Next(Planets.earthLikeSprites.Length);
                Data.materials.Add(Materials.IRON);
                if (random.Next(3) == 1)
                {
                    Data.materials.Add(Materials.TUNGSTEN);
                }
                if (random.Next(5) == 1)
                {
                    Data.materials.Add(Materials.GOLD);
                }
            }
            if (Data.type == PlanetType.LAVA)
            {
                Data.color[0] = (byte)(random.Next(150, 255));
                Data.color[1] = (byte)(random.Next(0, 50));
                Data.color[2] = (byte)(random.Next(0, 50));
                Data.scale = (float)(random.Next(2, 5) + random.NextDouble());
                Data.spriteNumber = random.Next(Planets.lavaSprites.Length);
                Data.materials.Add(Materials.COAL);
                if (random.Next(3) == 1)
                {
                    Data.materials.Add(Materials.GOLD);
                }
                if (random.Next(5) == 1)
                {
                    Data.materials.Add(Materials.TITAN);
                }
            }
            if (Data.type == PlanetType.ROCKY)
            {
                Data.color[0] = (byte)(random.Next(0, 255));
                Data.color[1] = (byte)(random.Next(0, 106));
                Data.color[2] = 0;
                Data.scale = (float)(random.Next(2, 7) + random.NextDouble());
                Data.spriteNumber = random.Next(Planets.rockySprites.Length);
                Data.materials.Add(Materials.IRON);
                if (random.Next(3) == 1)
                {
                    Data.materials.Add(Materials.COPPER);
                }
                if (random.Next(5) == 1)
                {
                    Data.materials.Add(Materials.TIN);
                }
            }
            if (Data.type == PlanetType.GAS)
            {
                Data.color[0] = (byte)(random.Next(255));
                Data.color[1] = (byte)(random.Next(255));
                Data.color[2] = (byte)(random.Next(255));
                Data.scale = (float)(random.Next(7, 15) + random.NextDouble());
                Data.spriteNumber = random.Next(Planets.gasSprites.Length);
                Data.materials.Add(Materials.COPPER);
                if (random.Next(3) == 1)
                {
                    Data.materials.Add(Materials.NICKEL);
                }
                if (random.Next(5) == 1)
                {
                    Data.materials.Add(Materials.TIN);
                }
            }
            if (Data.type == PlanetType.ICE)
            {
                Data.color[0] = (byte)(random.Next(200,255));
                Data.color[1] = (byte)(random.Next(135,255));
                Data.color[2] = (byte)(random.Next(200,255));
                Data.scale = (float)(random.Next(4, 14) + random.NextDouble());
                Data.spriteNumber = random.Next(Planets.iceSprites.Length);
                Data.materials.Add(Materials.NICKEL);
                if (random.Next(3) == 1)
                {
                    Data.materials.Add(Materials.COPPER);
                }
                if (random.Next(5) == 1)
                {
                    Data.materials.Add(Materials.TIN);
                }
            }
            Data.speed = (float)(random.NextDouble()) / 5;
            Map.Data.planets.Add(Data.name);
            Debug.Log("Generated Planet: " + Data.name);
        }
        for (int i = 0; i < text.Length; i++)
        {
            text[i].GetComponent<TextMeshPro>().text = Data.name + "\n" + Data.type.ToString();
            text[0].GetComponent<TextMeshPro>().fontSize /= 4;
        }
        if (Data.type == PlanetType.EXOTIC) {
            planetBody.GetComponent<SpriteRenderer>().sprite = Planets.exoticSprites[Data.spriteNumber];
            miniMap.GetComponent<SpriteRenderer>().sprite = Planets.exoticSprites[Data.spriteNumber]; }
        if (Data.type == PlanetType.EARTHLIKE) {
            planetBody.GetComponent<SpriteRenderer>().sprite = Planets.earthLikeSprites[Data.spriteNumber];
            miniMap.GetComponent<SpriteRenderer>().sprite = Planets.earthLikeSprites[Data.spriteNumber]; }
        if (Data.type == PlanetType.LAVA) {
            planetBody.GetComponent<SpriteRenderer>().sprite = Planets.lavaSprites[Data.spriteNumber];
            miniMap.GetComponent<SpriteRenderer>().sprite = Planets.lavaSprites[Data.spriteNumber]; }
        if (Data.type == PlanetType.ROCKY) {
            planetBody.GetComponent<SpriteRenderer>().sprite = Planets.rockySprites[Data.spriteNumber];
            miniMap.GetComponent<SpriteRenderer>().sprite = Planets.rockySprites[Data.spriteNumber]; }
        if (Data.type == PlanetType.GAS) {
            planetBody.GetComponent<SpriteRenderer>().sprite = Planets.gasSprites[Data.spriteNumber];
            miniMap.GetComponent<SpriteRenderer>().sprite = Planets.gasSprites[Data.spriteNumber]; }
        if (Data.type == PlanetType.ICE) {
            planetBody.GetComponent<SpriteRenderer>().sprite = Planets.iceSprites[Data.spriteNumber];
            miniMap.GetComponent<SpriteRenderer>().sprite = Planets.iceSprites[Data.spriteNumber]; }
        planetMain.name = Data.name;
        planetBody.name = Data.name + "-Body";
        planetMain.transform.position = new Vector3(Data.position_x, Data.position_y,-780f);
        planetMain.transform.localScale = new Vector3(Data.scale, Data.scale, 1);
        informationText.text = "Materials: ";
        for (var i = 0; i < Data.materials.Count; i++)
        {
            informationText.text += Data.materials[i].ToString() + ", ";
        }

        informationText.text += "\nDrills: PLACEHOLDER";
        for (var i = 0; i < lights.Length; i++)
        {
            lights[i].GetComponent<Light2D>().color = new Color32(Data.color[0], Data.color[1], Data.color[2], 255);
            lights[i].GetComponent<Light2D>().pointLightOuterRadius += (float)((Data.scale / 2.5));
        }

        for (var i = 0; i < athmospheres.Length; i++)
        {
            athmospheres[i].GetComponent<SpriteRenderer>().color = new Color32(Data.color[0], Data.color[1], Data.color[2], 255);
        }

        if (MapOptions.Data.Moons)
        {
            for (var i = 0; i < Data.moonAmount; i++)
            {
                GameObject moon = GameObject.Instantiate(moonDummy, planetMain.transform, false);
                moon.GetComponent<Orbit>().target = planetBody;
                moon.GetComponent<Orbit>().speed = random.Next(2) + (float) (random.NextDouble()) / 5;
                Moon moonObject = Moons.AddMoon(new Moon(moon, Data.name, this));
                moonObject.Generate();
                moonObject.SaveAsMoon();
                moon.SetActive(true);
            }
        }

        for (var i = 0; i < Data.spaceStationAmount; i++)
        {
            GameObject spaceStation = GameObject.Instantiate(spaceStationDummy, planetMain.transform, false);
            spaceStation.GetComponent<Orbit>().target = planetBody;
            spaceStation.GetComponent<Orbit>().speed = random.Next(2) + (float)(random.NextDouble()) / 5;
            SpaceStation spaceStationObject = SpaceStations.AddSpaceStation(new SpaceStation(spaceStation, Data.name, this));
            spaceStationObject.Generate();
            spaceStationObject.SaveAsSpaceStation();
            spaceStation.SetActive(true);
        }
       for (var i = 0; i < drillAmount; i++)
       {
            GameObject drill = GameObject.Instantiate(drillDummy, planetMain.transform, false);
            drill.GetComponent<Orbit>().target = planetBody;
            drill.GetComponent<Orbit>().speed = (float)(random.NextDouble()) / 5;
            drill.SetActive(true);
       }
       Map.Save();
    }

    public PlanetData Load(string name)
    {
        Data.Load(name);
        return Data;
    }

    public void Save()
    {
        Data.Save();
    }
}

public class PlanetData
{
    public string name = "Unknown";
    public int id = 0;
    public float position_x = 0;
    public float position_y = 0;
    public List<Materials> materials = new List<Materials>();
    public byte[] color = { 255, 255, 255 };
    public PlanetType type = PlanetType.LAVA;
    public int moonAmount = 0;
    public float scale = 1;
    public float speed = 0.5f;
    public int spriteNumber = 0;
    public List<string> moons = new List<string>();
    public int spaceStationAmount = 0;
    public List<string> spaceStations = new List<string>();

    public void Load(string planetName)
    {
        Debug.Log("Loading Star... " + planetName + "_" + name);
        string json = "{}";
        if (File.Exists(Registry.profile.map_path + "/planets/" + name + "/data" + ".json"))
        {
            json = File.ReadAllText(Registry.profile.map_path + "/planets/" + name + "/data" + ".json");
        }
        else
        {
            Save(planetName);
        }
        JsonUtility.FromJsonOverwrite(json, this);   
    }
        
    public void Save(string planetName)
    {
        if (!Directory.Exists(Registry.profile.map_path + "/planets/" + name + "/"))
        {
            Directory.CreateDirectory(Registry.profile.map_path + "/planets/" + name + "/");
        }
        File.WriteAllText(Registry.profile.map_path + "/planets/" + name + "/data" + ".json", JsonUtility.ToJson(this, true));
    }

    public void Save()
    {
        Save(name);
    }
    
}
