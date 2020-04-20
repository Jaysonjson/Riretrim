using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public static int current_planet_id = 0;
    public static List<string> planets = new List<string>();

    public static void load()
    {
        MapData data = MapSave.load();
        planets = data.planets;
    }

    public static void save()
    {
        MapSave.save();
    }
}
