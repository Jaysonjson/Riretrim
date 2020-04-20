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
        if (material == Materials.ALUMINIUM)
        {
            Profile.aluminium_amount += amount;
        }
        if (material == Materials.TIN)
        {
            Profile.tin_amount += amount;
        }
        if (material == Materials.TITAN)
        {
            Profile.titan_amount += amount;
        }
        if (material == Materials.BRONZE)
        {
            Profile.bronze_amount += amount;
        }
        if (material == Materials.GOLD)
        {
            Profile.gold_amount += amount;
        }
        if (material == Materials.NICKEL)
        {
            Profile.nickel_amount += amount;
        }
        if (material == Materials.TUNGSTEN)
        {
            Profile.tungsten_amount += amount;
        }
        if (material == Materials.CRYSTAL)
        {
            Profile.crystal_amount += amount;
        }
        if (material == Materials.IRON)
        {
            Profile.iron_amount += amount;
        }
        if (material == Materials.COPPER)
        {
            Profile.copper_amount += amount;
        }
        if (material == Materials.COAL)
        {
            Profile.coal_amount += amount;
        }
    }
}
