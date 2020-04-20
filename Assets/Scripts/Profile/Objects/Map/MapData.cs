using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MapData
{
    public List<string> planets;
    public MapData()
    {
        planets = Map.planets;
    }
}
