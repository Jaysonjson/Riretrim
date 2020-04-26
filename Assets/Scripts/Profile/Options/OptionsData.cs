using System;

[System.Serializable]
public class OptionsData
{
    public float asteroidDespawnDistance;
    public bool asteroidShadows;
    public bool particleSystems;
    public bool objectShadows;
    
    public OptionsData()
    {
        asteroidDespawnDistance = Options.AsteroidDespawnDistance;
        asteroidShadows = Options.AsteroidShadows;
        particleSystems = Options.ParticleSystems;
        objectShadows = Options.ObjectShadows;
    }
}