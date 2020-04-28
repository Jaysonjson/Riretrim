[System.Serializable]
public class MapOptionsData
{
    public int asteroidMaxSpawnAmount;
    public int asteroidMinSpawnAmount;
    public int planetMaxAmount;
    public bool shipWrecks;
    public bool moons;
    public MapOptionsData()
    {
        asteroidMaxSpawnAmount = MapOptions.AsteroidMaxSpawnAmount;
        asteroidMinSpawnAmount = MapOptions.AsteroidMinSpawnAmount;
        shipWrecks = MapOptions.ShipWrecks;
        moons = MapOptions.Moons;
        planetMaxAmount = MapOptions.PlanetMaxAmount;
    }
}