using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MaterialPickUp : MonoBehaviour
{
    public Materials material;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            if (material == Materials.ALUMINIUM)
            {
                Profile.aluminium_amount++;
            }
            if (material == Materials.TIN)
            {
                Profile.tin_amount++;
            }
            if (material == Materials.TITAN)
            {
                Profile.titan_amount++;
            }
            if (material == Materials.BRONZE)
            {
                Profile.bronze_amount++;
            }
            if (material == Materials.GOLD)
            {
                Profile.gold_amount++;
            }
            if (material == Materials.NICKEL)
            {
                Profile.nickel_amount++;
            }
            if (material == Materials.TUNGSTEN)
            {
                Profile.tungsten_amount++;
            }
            if (material == Materials.CRYSTAL)
            {
                Profile.crystal_amount++;
            }
            if (material == Materials.IRON)
            {
                Profile.iron_amount++;
            }
            if (material == Materials.COPPER)
            {
                Profile.copper_amount++;
            }
            if (material == Materials.COAL)
            {
                Profile.coal_amount++;
            }
            SpaceMap.updateMaterialText();
            Destroy(gameObject);
            Profile.save();
        }
    }
}
