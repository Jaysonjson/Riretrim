public class MapOptions
{
    public static int AsteroidMaxSpawnAmount = 550;
    public static int AsteroidMinSpawnAmount = 125;
    public static bool ShipWrecks = true;
    public static void load()
    {
        MapOptionsData data = MapOptionsSave.load();
        AsteroidMaxSpawnAmount = data.asteroidMaxSpawnAmount;
        AsteroidMinSpawnAmount = data.asteroidMinSpawnAmount;
        ShipWrecks = data.shipWrecks;
    }

    public static void save()
    {
        MapOptionsSave.save();
    }
}