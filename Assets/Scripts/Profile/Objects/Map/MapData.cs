using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MapData
{
    public List<string> planets;
    public List<string> shipwrecks;
    public MapData()
    {
        planets = Map.planets;
        shipwrecks = Map.shipwrecks;
    }
}
