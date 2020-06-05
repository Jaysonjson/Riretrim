using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Moon
{
    public string name;
    public float scale;
    public string planet;
    public int index;
    public Planet planetObject;
    public GameObject moon;

    public void Generate()
    {
        System.Random random = new System.Random();

            name = generateName(random);
           // scale = (planetObject.planetMain.transform.localScale.x / (float)(random.Next(3,6) + random.NextDouble())) / 7.5f;
            Debug.Log("Generated Moon: " + name + "; from Planet: " + planetObject.Data.name);
          //  planetObject.Data.moons.Add(name);
          //  planetObject.Data.Save();
        moon.name = name;
        moon.transform.localScale = new Vector3(scale,scale,1);
  
    }

    private string generateName(System.Random random)
    {
        string genName = Registry.Names.MOON[random.Next(Registry.Names.MOON.Count)] + "-" + random.Next(9999);
        if (planetObject.Data.moons.ContainsKey(genName))
        {
            return generateName(random);
        }
        return genName;
    }
}
