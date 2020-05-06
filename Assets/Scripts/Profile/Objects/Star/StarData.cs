using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StarDataOld
{
    public string solarSystem;
    public string sname;
    public float position_x;
    public float position_y;
    public float speed;
    public byte[] color;
    public int asteroid_count;
    public int shipwreck_count;
    public int planet_count;
    public bool secondSun;
    public float sunScale;
    public bool visited;
    public DateTime visitTime;
    public StarDataOld(Star star)
    {
        solarSystem = star.solarSystem;
        sname = star.sname;
        position_x = star.position_x;
        position_y = star.position_y;
        speed = star.speed;
        color = star.color;
        asteroid_count = star.asteroid_count;
        planet_count = star.planet_count;
        secondSun = star.secondSun;
        sunScale = star.sunScale;
        visited = star.visited;
        visitTime = star.visitTime;
        shipwreck_count = star.shipwreck_count;
    }
}