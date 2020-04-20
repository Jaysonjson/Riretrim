using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy
{
    public static int current_star_id = 0;
    public static List<string> stars = new List<string>();

    public static void load()
    {
        GalaxyData data = GalaxySave.load();
        stars = data.stars;
    }

    public static void save()
    {
        GalaxySave.save();
    }
}
