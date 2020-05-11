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
            switch (material)
            {
                case Materials.ALUMINIUM: Registry.profile.Data.aluminium_amount++; break;
                case Materials.TIN: Registry.profile.Data.tin_amount++; break;
                case Materials.TITAN: Registry.profile.Data.titan_amount++; break;
                case Materials.BRONZE: Registry.profile.Data.bronze_amount++; break;
                case Materials.GOLD: Registry.profile.Data.gold_amount++; break;
                case Materials.NICKEL: Registry.profile.Data.nickel_amount++; break;
                case Materials.TUNGSTEN: Registry.profile.Data.tungsten_amount++; break;
                case Materials.CRYSTAL: Registry.profile.Data.crystal_amount++; break;
                case Materials.IRON: Registry.profile.Data.iron_amount++; break;
                case Materials.COPPER: Registry.profile.Data.copper_amount++; break;
                case Materials.COAL: Registry.profile.Data.coal_amount++; break;
            }
            SpaceMap.INSTANCE.updateMaterialText();
            Destroy(gameObject);
            Registry.profile.Save();
        }
    }
}
