using System.Threading;
using Newtonsoft.Json;
using UnityEngine;

public class Moon
{
    public MoonData Data = new MoonData();
    public void Generate(MapGeneration map, Planet planet)
    {
        System.Random random = new System.Random();

        Data.name = generateName(random, planet);
        map.currentTask++;
        map.text = "Generating Moon...";
        // scale = (planetObject.planetMain.transform.localScale.x / (float)(random.Next(3,6) + random.NextDouble())) / 7.5f;
        planet.Data.moons.Add(Data.name, this);
    }

    private string generateName(System.Random random, Planet planet)
    {
        string genName = Registry.Names.MOON[random.Next(Registry.Names.MOON.Count)] + "-" + random.Next(9999);
        Thread.Sleep(12);
        if (planet.Data.moons.ContainsKey(genName))
        {
            return generateName(random, planet);
        }
        return genName;
    }
}

public class MoonData
{
    public string name = "";
    public float scale = 1;
}