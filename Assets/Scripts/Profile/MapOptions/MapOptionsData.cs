[System.Serializable]
public class MapOptionsData
{
    public int asteroidMaxSpawnAmount;
    public int asteroidMinSpawnAmount;
    public bool shipWrecks;
    public MapOptionsData()
    {
        asteroidMaxSpawnAmount = MapOptions.AsteroidMaxSpawnAmount;
        asteroidMinSpawnAmount = MapOptions.AsteroidMinSpawnAmount;
        shipWrecks = MapOptions.ShipWrecks;
    }
    
}