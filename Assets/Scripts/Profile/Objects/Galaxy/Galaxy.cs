using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
[System.Serializable]
public class Galaxy
{
    [JsonIgnore]
    private int nameTries = 0;
    public GalaxyData Data = new GalaxyData();

    [JsonIgnore]
    private System.Random random = new System.Random();

    public void Generate(MapGeneration map)
    {
        map.text = "Finding Name...";
        Data.name = generateName(random);
        map.text = "Generating Galaxy: " + Data.name;
        int starAmount = random.Next(50, 125);
        map.maxStarProgress = starAmount;
        map.starProgress = 0;
        for (int i = 0; i < starAmount; i++)
        {
            Star star = new Star(this);
            star.Generate(map);
            map.starProgress++;
            map.starText = "Generating Star: " + star.Data.name + " (" + map.starProgress + " from " + map.maxStarProgress + " ) in Galaxy " + Data.name;
            if (!Data.stars.ContainsKey(star.Data.name))
            {
                Data.stars.Add(star.Data.name, star);
            }
        }
        map.maxTasks += starAmount;
        map.currentTask++;
        Registry.adventureMap.galaxies.Add(Data.name, this);
    }

    private string generateName(System.Random random)
    {
        nameTries++;
        Thread.Sleep(13);
        string genName = Registry.Names.GALAXY[random.Next(Registry.Names.GALAXY.Count)] + "-" + Registry.Names.SUFFIX[random.Next(Registry.Names.SUFFIX.Count)];
        if (nameTries < 1500)
        {
            if (Registry.adventureMap.galaxies.ContainsKey(genName))
            {
                return generateName(random);
            }
        }
        return genName;
    }

}

[System.Serializable]
public class GalaxyData
{
    public string name = "NotDefined";
    public Dictionary<string, Star> stars = new Dictionary<string, Star>();
}