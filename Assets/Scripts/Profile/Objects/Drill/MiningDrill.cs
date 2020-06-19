using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MiningDrill
{
    public int index;
    public string planet;
    public Materials material;
    public GameObject miningDrill;

    public MiningDrill(GameObject MiningDrill, string PlanetParent)
    {
        planet = PlanetParent;
        miningDrill = MiningDrill;
    }

    public bool Exists()
    {
        return Directory.Exists(Registry.profile.map_path + "/planets/" + planet + "/drills/" + index + "/");
    }

    public void Generate()
    {
        if(Exists())
        {
            LoadUsingIndex(planet, index + "");
            Debug.Log("Loaded Drill: " + index + "; from Planet: " + planet);
        } else if(!Exists()) {

        }

    }

    public void LoadUsingIndex(string PlanetParent, string Index)
    {
        MiningDrillData data = MiningDrillSave.LoadUsingIndex(PlanetParent, Index);
        material = data.material;
    }

    public void SaveAsMiningDrill()
    {
        MiningDrillSave.SaveNewMiningDrill(planet, this);
    }
}
