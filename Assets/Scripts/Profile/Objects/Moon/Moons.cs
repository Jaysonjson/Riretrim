using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moons
{
    public static Moon AddMoon(Moon moon)
    {
        moon.index = References.moons.Count;
        References.moons.Add(moon);
        return moon;
    }

    public static Moon GetMoon(int index)
    {
        return References.moons[index];
    }

    void Start()
    {
        Profile.load();
        AddMoon(new Moon());
    }

    public static void LoadMoons()
    {
        for (int i = 0; i < References.moons.Count; i++)
        {
            GetMoon(i).Generate();
            GetMoon(i).SaveAsMoon();
        }
    }
}
