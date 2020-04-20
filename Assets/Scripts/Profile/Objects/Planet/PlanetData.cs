using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanetData
{
    public string name;
    public bool generated;
    public int id;
    public float position_x;
    public float position_y;
    public List<Materials> materials;
    public List<string> moons;
    public List<string> spaceStations;

    public PlanetType type;
    public byte[] color;
    public int moonAmount;
    public float scale;
    public float speed;
    public int spriteNumber;
    public int spaceStationAmount;
    public PlanetData(int index)
    {
        name = Planets.GetPlanet(index).getName();
        //generated = Planets.GetPlanet(index).generated;
        id = Planets.GetPlanet(index).id;
        position_x = Planets.GetPlanet(index).position_x;
        position_y = Planets.GetPlanet(index).position_y;
        materials = Planets.GetPlanet(index).materials;
        type = Planets.GetPlanet(index).type;
        color = Planets.GetPlanet(index).color;
        moonAmount = Planets.GetPlanet(index).moonAmount;
        scale = Planets.GetPlanet(index).scale;
        speed = Planets.GetPlanet(index).speed;
        spriteNumber = Planets.GetPlanet(index).spriteNumber;
        moons = Planets.GetPlanet(index).moons;
        spaceStationAmount = Planets.GetPlanet(index).spaceStationAmount;
        spaceStations = Planets.GetPlanet(index).spaceStations;
    }
}