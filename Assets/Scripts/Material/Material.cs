using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    public bool spaceMap;
    System.Random Random = new System.Random();
    void Start()
    {
        if(spaceMap)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * (float)Random.NextDouble());
        }
    }

    void Update()
    {
        if (spaceMap)
        {
            transform.Rotate(0, 0, 0.15f);
            //if(new System.Random().Next(300) == 1)
            //{
            //    GetComponent<Rigidbody2D>().AddForce(transform.up * 0.00001f);
            //    Debug.Log("Force Update");
            //}
        }
    }

    public static void addMaterial(Materials material, int amount)
    {
        switch (material)
        {
            case Materials.ALUMINIUM: Registry.profile.Data.aluminium_amount += amount; break;
            case Materials.TIN: Registry.profile.Data.tin_amount += amount; break;
            case Materials.TITAN: Registry.profile.Data.titan_amount += amount; break;
            case Materials.BRONZE: Registry.profile.Data.bronze_amount += amount; break;
            case Materials.GOLD: Registry.profile.Data.gold_amount += amount; break;
            case Materials.NICKEL: Registry.profile.Data.nickel_amount += amount; break;
            case Materials.TUNGSTEN: Registry.profile.Data.tungsten_amount += amount; break;
            case Materials.CRYSTAL: Registry.profile.Data.crystal_amount += amount; break;
            case Materials.IRON: Registry.profile.Data.iron_amount += amount; break;
            case Materials.COPPER: Registry.profile.Data.copper_amount += amount; break;
            case Materials.COAL: Registry.profile.Data.coal_amount += amount; break;
        }
        Registry.profile.Save();
    }
}
