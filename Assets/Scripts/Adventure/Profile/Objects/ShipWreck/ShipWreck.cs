using System.Threading;
using System.Linq;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
public class ShipWreck
{
    public ShipWreckData Data = new ShipWreckData();

    [JsonIgnore]
    public Star star;

    private int nameTries = 0;
    public ShipWreck(Star star)
    {
        this.star = star;
    }

    public void Generate(MapGeneration map)
    {
        System.Random random = new System.Random();
        //map.currentTask++;
        Data.name = generateName(random);
        map.text = "Generating Shipwreck: " + Data.name + " from Star: " + star.Data.name;
        Data.type = map.shipWreckNames[random.Next(map.shipWreckNames.Count)];
        star.Data.shipWrecks.Add(Data.name, this);
    }

    private string generateName(System.Random random)
    {
        nameTries++;
        string genName = Registry.Names.OTHER[random.Next(Registry.Names.OTHER.Count)] + "-" + random.Next(9999);
        Thread.Sleep(13);
        if (nameTries < 75)
        {
            if (star.Data.shipWrecks.ContainsKey(genName))
            {
                return generateName(random);
            }
        }
        return genName;
    }
}
public class ShipWreckData
{
    public string name = "";
    public string type = "ShipWreck-0";
}