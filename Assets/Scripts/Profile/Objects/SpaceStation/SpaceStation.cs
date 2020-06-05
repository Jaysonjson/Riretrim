using System.Threading;
using Newtonsoft.Json;
using UnityEngine;

public class SpaceStation
{
    [JsonIgnore]
    private int nameTries = 0;
    public SpaceStationData Data = new SpaceStationData();
    public void Generate(MapGeneration map, Planet planet)
    {
        System.Random random = new System.Random();
        Data.name = generateName(random, planet);
        //scale = (planetObject.planetMain.transform.localScale.x / (float)(random.Next(3, 6) + random.NextDouble())) / 5.5f;
        map.currentTask++;
        map.text = "Generating Space Station: " + Data.name + "; from Planet: " + planet.Data.name;
        //Debug.Log("Generated Space Station: " + Data.name + "; from Planet: " + planet.Data.name);
        planet.Data.spaceStations.Add(Data.name, this);
    }

    private string generateName(System.Random random, Planet planet)
    {
        nameTries++;
        Thread.Sleep(13);
        string genName = Registry.Names.SPACESTATION[new System.Random().Next(Registry.Names.SPACESTATION.Count)] + "-" + new System.Random().Next(9999);
        if (nameTries < 1500)
        {
            if (planet.Data.spaceStations.ContainsKey(genName))
            {
                return generateName(random, planet);
            }
        }
        return genName;
    }
}

[System.Serializable]
public class SpaceStationData
{
    public string name;
    public float scale;
}