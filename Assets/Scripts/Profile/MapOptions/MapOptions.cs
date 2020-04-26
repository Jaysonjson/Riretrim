public class MapOptions
{
    public static int asteroid_max_spawn_amount = 550;
    public static int asteroid_min_spawn_amount = 75;
    public static bool shipwrecks = true;
    public static void load()
    {
        MapOptionsData data = MapOptionsSave.load();
        asteroid_max_spawn_amount = data.asteroid_max_spawn_amount;
        asteroid_min_spawn_amount = data.asteroid_min_spawn_amount;
        shipwrecks = data.shipwrecks;
    }

    public static void save()
    {
        MapOptionsSave.save();
    }
}