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
                case Materials.ALUMINIUM: Profile.Data.aluminium_amount++; break;
                case Materials.TIN: Profile.Data.tin_amount++; break;
                case Materials.TITAN: Profile.Data.titan_amount++; break;
                case Materials.BRONZE: Profile.Data.bronze_amount++; break;
                case Materials.GOLD: Profile.Data.gold_amount++; break;
                case Materials.NICKEL: Profile.Data.nickel_amount++; break;
                case Materials.TUNGSTEN: Profile.Data.tungsten_amount++; break;
                case Materials.CRYSTAL: Profile.Data.crystal_amount++; break;
                case Materials.IRON: Profile.Data.iron_amount++; break;
                case Materials.COPPER: Profile.Data.copper_amount++; break;
                case Materials.COAL: Profile.Data.coal_amount++; break;
            }
            SpaceMap.updateMaterialText();
            Destroy(gameObject);
            Profile.Save();
        }
    }
}
