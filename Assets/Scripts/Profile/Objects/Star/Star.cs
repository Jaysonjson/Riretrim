using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Star
{
    public StarData Data = new StarData();
    public int id;
    public int index;
    public GameObject text;
    public GameObject star;
    public Star(GameObject text, GameObject star)
    {
        this.text = text;
        this.star = star;
    }
    public Star()
    {
    }

    public bool Exists()
    {
        if (Galaxy.stars.Count < index + 1)
        {
            return false;
        }
        Data.name = Galaxy.stars[index];
        return Directory.Exists(Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + Galaxy.stars[index] + "/");
    }

    public void Generate()
    {
        Galaxy.load();
        System.Random random = new System.Random();
        if (Exists())
        {
            Load(Stars.GetStar(index).Data.name);
            Debug.Log("Loaded Star: " + Data.name);
        }
        if (!Exists())
        {
            Data.name = References.randomNames[random.Next(References.randomNames.Length)] + "-" + random.Next(9999);
            id = random.Next(99999);
            Data.solarSystem = Data.name;
            Data.asteroid_count = random.Next(MapOptions.AsteroidMinSpawnAmount, MapOptions.AsteroidMaxSpawnAmount);
            Data.planet_count = random.Next(MapOptions.PlanetMaxAmount / 4);
            Data.shipwreck_count = random.Next(2, 25);
            Data.sunScale = (float)(random.Next(15,35) + random.NextDouble());
            if(random.Next(1) == 1)
            {
                Data.secondSun = true;
            }
            if(random.Next(10) == 1)
            {
                Data.planet_count = random.Next(MapOptions.PlanetMaxAmount / 2);
            }
            if (random.Next(25) == 1)
            {
                Data.planet_count = random.Next(MapOptions.PlanetMaxAmount);
            }
            Data.position_x = (float)(random.Next(-5, 5) + random.NextDouble());
            Data.position_y = (float)(random.Next(-4, 4) + random.NextDouble());
            Data.speed = (float)random.Next(1, 6) / 10 + (float)random.Next(1,9) / 100;
            // color[] = Stars.colors[random.Next(Stars.colors.Length)];
            if(random.Next(3) == 1)
            {
                Data.color[0] = (byte)(random.Next(250));
                Data.color[1] = (byte)(random.Next(250));
                Data.color[2] = (byte)(random.Next(250));
            }
            Galaxy.stars.Add(Data.name);
            Debug.Log("Generated Star: " + Data.name);
        }
        text.GetComponent<TextMeshPro>().text = Data.name + "\nLast Visited on: " + Data.visitTime.ToString("dd/M/yyyy hh:mm:ss");
        if(Data.visited)
        {
            text.GetComponent<TextMeshPro>().color = new Color32(0, 163, 14, 255);
        } else
        {
            text.GetComponent<TextMeshPro>().color = new Color32(163, 0, 0, 255);
        }
        star.name = Data.name;
        star.GetComponent<Orbit>().speed = Data.speed;
        //star.GetComponent<SpriteRenderer>().color = color;
        star.GetComponent<SpriteRenderer>().color = new Color32(Data.color[0],Data.color[1],Data.color[2], 255);
        star.transform.position = new Vector2(Data.position_x, Data.position_y);
        Galaxy.save();
    }


    public void Load(string starName)
    {
        Data.Load(starName);
    }
    public void Save(string starName)
    {
        Data.Save(starName);
    }
}
public class StarData
{
    public string solarSystem = "";
    public string name = "";
    public int asteroid_count = 0;
    public int planet_count = 0;
    public int shipwreck_count = 0;
    public float position_x = 0;
    public float position_y = 0;
    public float speed = 0;
    public bool secondSun = false;
    public bool visited = false;
    public float sunScale = 1;
    public DateTime visitTime = new DateTime();
    public byte[] color = { 253, 184, 19 };
    
    public void Load(string starName)
    {
        Debug.Log("Loading Star... " + starName + "_" + name);
        string json = "{}";
        if (File.Exists(Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + starName + "/data.json"))
        {
            json = File.ReadAllText(Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + starName + "/data.json");
        }
        else
        {
            Save(starName);
        }
        JsonUtility.FromJsonOverwrite(json, this);   
    }
        
    public void Save(string starName)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + starName + "/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + starName + "/");
        }
        File.WriteAllText(Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + starName + "/data.json", JsonUtility.ToJson(this, true));
    }

    public void Save()
    {
        Save(name);
    }
}
