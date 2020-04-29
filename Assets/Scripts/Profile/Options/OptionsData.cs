using System;
using UnityEngine;

[System.Serializable]
public class OptionsData
{
    public float asteroidDespawnDistance;
    public bool asteroidShadows;
    public bool particleSystems;
    public bool objectShadows;
    public bool lights;
    public bool showFPS;
    public string language;
    public OptionsData()
    {
        asteroidDespawnDistance = Options.AsteroidDespawnDistance;
        asteroidShadows = Options.AsteroidShadows;
        particleSystems = Options.ParticleSystems;
        objectShadows = Options.ObjectShadows;
        lights = Options.Lights;
        showFPS = Options.ShowFPS;
        language = Options.Language;
    }
}