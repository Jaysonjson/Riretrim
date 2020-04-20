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
    public string pname = "Unknown";
    public int id;
    public string[] names = {"Dix","Apol","Zert","Kepler","Keygrocarro","Uphocarro","Bunrao","Vogov","Iruta","Ouwei","Vaditera","Phucetis"};
    public int index;
    public List<Materials> materials = new List<Materials>();
    public float position_x;
    public float position_y;
    public float scale;
    public float speed;
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
    public PlanetType type;
    public List<string> moons = new List<string>();
    public List<string> spaceStations = new List<string>();
    public int moonAmount;
    public int spaceStationAmount;
    public int spriteNumber;
    float dist;
    public byte[] color = { 255, 255, 255 };

    public string getName()
    {
        return this.pname;
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
        if(Map.planets.Count < index + 1)
        {
            return false;
        }
        pname = Map.planets[index];
        return Directory.Exists(Profile.map_path + "/planets/" + Map.planets[index] + "/");
    }

    public void Generate()
    {
        Map.load();
        System.Random random = new System.Random();
        if (Exists()) {
            load(index);
            Debug.Log("Loaded Planet: " + pname);
        }
        if (!Exists())
        {
            planetMain.GetComponent<Orbit>().speed = random.Next(120, 500);
            pname = names[random.Next(names.Length)] + "-" + random.Next(9999);
            id = random.Next(99999999);
            moonAmount = random.Next(4);
            if (random.Next(3) == 1)
            {
                moonAmount = random.Next(3);
                if(random.Next(3) == 1)
                {
                    moonAmount = random.Next(5);
                }
                if (random.Next(6) == 1)
                {
                    moonAmount = random.Next(10);
                }
            }
            spaceStationAmount = random.Next(2);

            if (random.Next(3) == 1)
            {
                spaceStationAmount = random.Next(2);
            }
            position_x = (float)(random.Next(-200, 200) + 1.25 + random.NextDouble());
            Array types = Enum.GetValues(typeof(PlanetType));
            type = (PlanetType)types.GetValue(random.Next(types.Length));
            dist = Vector2.Distance(sun.transform.position, new Vector2(position_x, position_y));
            scale = (float)( 5 + random.NextDouble());
            if (dist < 25){type = PlanetType.LAVA;}
            if (dist > 35){type = PlanetType.ROCKY;}
            if (dist > 55){type = PlanetType.EARTHLIKE;}
            if (dist > 90){type = PlanetType.GAS;}
            if (dist > 135){type = PlanetType.EXOTIC;}
            if (dist > 165){type = PlanetType.ICE;}

            if (type == PlanetType.EXOTIC)
            {
                color[0] = 255;
                color[1] = (byte)(random.Next(135));
                color[2] = 255;
                scale = (float)(random.Next(5,10) + random.NextDouble());
                spriteNumber = random.Next(Planets.exoticSprites.Length);
                materials.Add(Materials.ALUMINIUM);
                if (random.Next(3) == 1)
                {
                    materials.Add(Materials.TUNGSTEN);
                }
                if (random.Next(10) == 1)
                {
                    materials.Add(Materials.CRYSTAL);
                }
            }
            if (type == PlanetType.EARTHLIKE)
            {
                color[0] = 0;
                color[1] = (byte)(random.Next(135));
                color[2] = 255;
                scale = (float)(random.Next(3, 7) + random.NextDouble());
                spriteNumber = random.Next(Planets.earthLikeSprites.Length);
                materials.Add(Materials.IRON);
                if (random.Next(3) == 1)
                {
                    materials.Add(Materials.TUNGSTEN);
                }
                if (random.Next(5) == 1)
                {
                    materials.Add(Materials.GOLD);
                }
            }
            if (type == PlanetType.LAVA)
            {
                color[0] = (byte)(random.Next(150, 255));
                color[1] = (byte)(random.Next(0, 50));
                color[2] = (byte)(random.Next(0, 50));
                scale = (float)(random.Next(2, 5) + random.NextDouble());
                spriteNumber = random.Next(Planets.lavaSprites.Length);
                materials.Add(Materials.COAL);
                if (random.Next(3) == 1)
                {
                    materials.Add(Materials.GOLD);
                }
                if (random.Next(5) == 1)
                {
                    materials.Add(Materials.TITAN);
                }
            }
            if (type == PlanetType.ROCKY)
            {
                color[0] = (byte)(random.Next(0, 255));
                color[1] = (byte)(random.Next(0, 106));
                color[2] = 0;
                scale = (float)(random.Next(2, 7) + random.NextDouble());
                spriteNumber = random.Next(Planets.rockySprites.Length);
                materials.Add(Materials.IRON);
                if (random.Next(3) == 1)
                {
                    materials.Add(Materials.COPPER);
                }
                if (random.Next(5) == 1)
                {
                    materials.Add(Materials.TIN);
                }
            }
            if (type == PlanetType.GAS)
            {
                color[0] = (byte)(random.Next(255));
                color[1] = (byte)(random.Next(255));
                color[2] = (byte)(random.Next(255));
                scale = (float)(random.Next(7, 15) + random.NextDouble());
                spriteNumber = random.Next(Planets.gasSprites.Length);
                materials.Add(Materials.COPPER);
                if (random.Next(3) == 1)
                {
                    materials.Add(Materials.NICKEL);
                }
                if (random.Next(5) == 1)
                {
                    materials.Add(Materials.TIN);
                }
            }
            if (type == PlanetType.ICE)
            {
                color[0] = (byte)(random.Next(200,255));
                color[1] = (byte)(random.Next(135,255));
                color[2] = (byte)(random.Next(200,255));
                scale = (float)(random.Next(4, 14) + random.NextDouble());
                spriteNumber = random.Next(Planets.iceSprites.Length);
                materials.Add(Materials.NICKEL);
                if (random.Next(3) == 1)
                {
                    materials.Add(Materials.COPPER);
                }
                if (random.Next(5) == 1)
                {
                    materials.Add(Materials.TIN);
                }
            }
            speed = (float)(random.NextDouble());
            Map.planets.Add(pname);
            Debug.Log("Generated Planet: " + pname);
        }
        for (int i = 0; i < text.Length; i++)
        {
            text[i].GetComponent<TextMeshPro>().text = pname + "\n" + type.ToString();
            text[0].GetComponent<TextMeshPro>().fontSize /= 4;
        }
        if (type == PlanetType.EXOTIC) {
            planetBody.GetComponent<SpriteRenderer>().sprite = Planets.exoticSprites[spriteNumber];
            miniMap.GetComponent<SpriteRenderer>().sprite = Planets.exoticSprites[spriteNumber]; }
        if (type == PlanetType.EARTHLIKE) {
            planetBody.GetComponent<SpriteRenderer>().sprite = Planets.earthLikeSprites[spriteNumber];
            miniMap.GetComponent<SpriteRenderer>().sprite = Planets.earthLikeSprites[spriteNumber]; }
        if (type == PlanetType.LAVA) {
            planetBody.GetComponent<SpriteRenderer>().sprite = Planets.lavaSprites[spriteNumber];
            miniMap.GetComponent<SpriteRenderer>().sprite = Planets.lavaSprites[spriteNumber]; }
        if (type == PlanetType.ROCKY) {
            planetBody.GetComponent<SpriteRenderer>().sprite = Planets.rockySprites[spriteNumber];
            miniMap.GetComponent<SpriteRenderer>().sprite = Planets.rockySprites[spriteNumber]; }
        if (type == PlanetType.GAS) {
            planetBody.GetComponent<SpriteRenderer>().sprite = Planets.gasSprites[spriteNumber];
            miniMap.GetComponent<SpriteRenderer>().sprite = Planets.gasSprites[spriteNumber]; }
        if (type == PlanetType.ICE) {
            planetBody.GetComponent<SpriteRenderer>().sprite = Planets.iceSprites[spriteNumber];
            miniMap.GetComponent<SpriteRenderer>().sprite = Planets.iceSprites[spriteNumber]; }
        planetMain.name = pname;
        planetBody.name = pname + "-Body";
        planetMain.transform.position = new Vector3(position_x, position_y,-780f);
        planetMain.transform.localScale = new Vector3(scale, scale, 1);
        informationText.text = "Materials: ";
        for (var i = 0; i < materials.Count; i++)
        {
            informationText.text += materials[i].ToString() + ", ";
        }

        informationText.text += "\nDrills: PLACEHOLDER";
        for (var i = 0; i < lights.Length; i++)
        {
            lights[i].GetComponent<Light2D>().color = new Color32(color[0], color[1], color[2], 255);
            lights[i].GetComponent<Light2D>().pointLightOuterRadius += (float)((scale / 2.5));
        }

        for (var i = 0; i < athmospheres.Length; i++)
        {
            athmospheres[i].GetComponent<SpriteRenderer>().color = new Color32(color[0], color[1], color[2], 255);
        }

        for (var i = 0; i < moonAmount; i++)
        {
            GameObject moon = GameObject.Instantiate(moonDummy, planetMain.transform, false);
            moon.GetComponent<Orbit>().target = planetBody;
            moon.GetComponent<Orbit>().speed = random.Next(5) + (float)(random.NextDouble());
            Moon moonObject = Moons.AddMoon(new Moon(moon, pname, this));
            moonObject.Generate();
            moonObject.SaveAsMoon();
            moon.SetActive(true);
        }
        for (var i = 0; i < spaceStationAmount; i++)
        {
            GameObject spaceStation = GameObject.Instantiate(spaceStationDummy, planetMain.transform, false);
            spaceStation.GetComponent<Orbit>().target = planetBody;
            spaceStation.GetComponent<Orbit>().speed = random.Next(5) + (float)(random.NextDouble());
            SpaceStation spaceStationObject = SpaceStations.AddSpaceStation(new SpaceStation(spaceStation, pname, this));
            spaceStationObject.Generate();
            spaceStationObject.SaveAsSpaceStation();
            spaceStation.SetActive(true);
        }
       for (var i = 0; i < drillAmount; i++)
       {
            GameObject drill = GameObject.Instantiate(drillDummy, planetMain.transform, false);
            drill.GetComponent<Orbit>().target = planetBody;
            drill.GetComponent<Orbit>().speed = (float)(random.NextDouble());
            drill.SetActive(true);
       }
       Map.save();
    }

    public void load(int index)
    {
        PlanetData data = PlanetSave.load(index);
        pname = data.name;
        id = data.id;
        position_x = data.position_x;
        position_y = data.position_y;
        materials = data.materials;
        color = data.color;
        type = data.type;
        moonAmount = data.moonAmount;
        scale = data.scale;
        speed = data.speed;
        spriteNumber = data.spriteNumber;
        moons = data.moons;
        spaceStationAmount = data.spaceStationAmount;
        spaceStations = data.spaceStations;
    }

    public void LoadUsingName(string name)
    {
        PlanetData data = PlanetSave.LoadUsingName(name);
        pname = data.name;
        id = data.id;
        position_x = data.position_x;
        position_y = data.position_y;
        materials = data.materials;
        color = data.color;
        type = data.type;
        moonAmount = data.moonAmount;
        scale = data.scale;
        speed = data.speed;
        spriteNumber = data.spriteNumber;
        moons = data.moons;
        spaceStationAmount = data.spaceStationAmount;
        spaceStations = data.spaceStations;
    }

    public void save(int index)
    {
        PlanetSave.save(index);
    }


}
