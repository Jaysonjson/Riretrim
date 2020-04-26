public class MapOptions
{
    public static int asteroid_max_spawn_amount = 750;
    public static int asteroid_min_spawn_amount = 100;
    
    public static void load()
    {
        MapOptionsData data = MapOptionsSave.load();
        asteroid_max_spawn_amount = data.asteroid_max_spawn_amount;
        asteroid_min_spawn_amount = data.asteroid_min_spawn_amount;
    }

    public static void save()
    {
        MapOptionsSave.save();
    }
}