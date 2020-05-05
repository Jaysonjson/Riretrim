using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Star
{
    public string solarSystem;
    public string sname;
    public int asteroid_count;
    public int planet_count;
    public int shipwreck_count;
    public int id;
    public int index;
    public GameObject text;
    public GameObject star;
    public float position_x;
    public float position_y;
    public float speed;
    public bool secondSun;
    public bool visited = false;
    public float sunScale;
    public DateTime visitTime;
    public byte[] color = { 253, 184, 19 };
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
        sname = Galaxy.stars[index];
        return Directory.Exists(Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Profile.Data.current_galaxy + "/stars/" + Galaxy.stars[index] + "/");
    }

    public void Generate()
    {
        Galaxy.load();
        System.Random random = new System.Random();
        if (Exists())
        {
            load(index);
            Debug.Log("Loaded Star: " + sname);
        }
        if (!Exists())
        {
            sname = References.randomNames[random.Next(References.randomNames.Length)] + "-" + random.Next(9999);
            id = random.Next(99999);
            solarSystem = sname;
            asteroid_count = random.Next(MapOptions.AsteroidMinSpawnAmount, MapOptions.AsteroidMaxSpawnAmount);
            planet_count = random.Next(MapOptions.PlanetMaxAmount / 4);
            shipwreck_count = random.Next(2, 25);
            sunScale = (float)(random.Next(15,35) + random.NextDouble());
            if(random.Next(1) == 1)
            {
                secondSun = true;
            }
            if(random.Next(10) == 1)
            {
                planet_count = random.Next(MapOptions.PlanetMaxAmount / 2);
            }
            if (random.Next(25) == 1)
            {
                planet_count = random.Next(MapOptions.PlanetMaxAmount);
            }
            position_x = (float)(random.Next(-5, 5) + random.NextDouble());
            position_y = (float)(random.Next(-4, 4) + random.NextDouble());
            speed = (float)random.Next(1, 6) / 10 + (float)random.Next(1,9) / 100;
            // color[] = Stars.colors[random.Next(Stars.colors.Length)];
            if(random.Next(3) == 1)
            {
                color[0] = (byte)(random.Next(250));
                color[1] = (byte)(random.Next(250));
                color[2] = (byte)(random.Next(250));
            }
            Galaxy.stars.Add(sname);
            Debug.Log("Generated Star: " + sname);
        }
        text.GetComponent<TextMeshPro>().text = sname + "\nLast Visited on: " + visitTime.ToString("dd/M/yyyy hh:mm:ss");
        if (visited)
        {
            text.GetComponent<TextMeshPro>().color = new Color32(0, 163, 14, 255);
        } else
        {
            text.GetComponent<TextMeshPro>().color = new Color32(163, 0, 0, 255);
        }
        star.name = sname;
        star.GetComponent<Orbit>().speed = speed;
        //star.GetComponent<SpriteRenderer>().color = color;
        star.GetComponent<SpriteRenderer>().color = new Color32(color[0],color[1],color[2], 255);
        star.transform.position = new Vector2(position_x, position_y);
        Galaxy.save();
    }

    public void load(int index)
    {
        StarData data = StarSave.load(index);
        solarSystem = data.solarSystem;
        sname = data.sname;
        position_x = data.position_x;
        position_y = data.position_y;
        speed = data.speed;
        color = data.color;
        asteroid_count = data.asteroid_count;
        planet_count = data.planet_count;
        secondSun = data.secondSun;
        sunScale = data.sunScale;
        visited = data.visited;
        visitTime = data.visitTime;
    }

    public void LoadUsingName(string name)
    {
        StarData data = StarSave.LoadUsingName(name);
        solarSystem = data.solarSystem;
        sname = data.sname;
        position_x = data.position_x;
        position_y = data.position_y;
        speed = data.speed;
        color = data.color;
        asteroid_count = data.asteroid_count;
        planet_count = data.planet_count;
        shipwreck_count = data.shipwreck_count;
        secondSun = data.secondSun;
        sunScale = data.sunScale;
        visited = data.visited;
        visitTime = data.visitTime;
    }

    public void Save(int index)
    {
        StarSave.save(index);
    }
    public void SaveAsStar()
    {
        StarSave.saveNewstar(this);
    }
}
