using System;
using UnityEngine;

public class ShipWrecks : MonoBehaviour
{
    public GameObject[] types;
    
    public ShipWreck addShipWreck(ShipWreck shipwreck)
    {
        shipwreck.index = References.shipwrecks.Count;
        References.shipwrecks.Add(shipwreck);
        return shipwreck;
    }

    public static ShipWreck GetShipWreck(int index)
    {
        return References.shipwrecks[index];
    }

    public static void LoadShipWrecks()
    {
        for (int i = 0; i < References.shipwrecks.Count; i++)
        {
            GetShipWreck(i).Generate();
            GetShipWreck(i).Save();
        }
    }

    private void Start()
    {
        addShipWreck(new ShipWreck(types[new System.Random().Next(types.Length)].name, gameObject));
    }
}