using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    public bool spaceMap;
    void Start()
    {
        if(spaceMap)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 0.5f);
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
            case Materials.ALUMINIUM: Profile.Data.aluminium_amount += amount; break;
            case Materials.TIN: Profile.Data.tin_amount += amount; break;
            case Materials.TITAN: Profile.Data.titan_amount += amount; break;
            case Materials.BRONZE: Profile.Data.bronze_amount += amount; break;
            case Materials.GOLD: Profile.Data.gold_amount += amount; break;
            case Materials.NICKEL: Profile.Data.nickel_amount += amount; break;
            case Materials.TUNGSTEN: Profile.Data.tungsten_amount += amount; break;
            case Materials.CRYSTAL: Profile.Data.crystal_amount += amount; break;
            case Materials.IRON: Profile.Data.iron_amount += amount; break;
            case Materials.COPPER: Profile.Data.copper_amount += amount; break;
            case Materials.COAL: Profile.Data.coal_amount += amount; break;
        }
        Profile.Save();
    }
}
