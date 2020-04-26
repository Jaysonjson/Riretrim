[System.Serializable]
public class MapOptionsData
{
    public int asteroid_max_spawn_amount;
    public int asteroid_min_spawn_amount;
    public bool shipwrecks;
    public MapOptionsData()
    {
        asteroid_max_spawn_amount = MapOptions.asteroid_max_spawn_amount;
        asteroid_min_spawn_amount = MapOptions.asteroid_min_spawn_amount;
        shipwrecks = MapOptions.shipwrecks;
    }
    
}