using System.Linq;
using System;
using UnityEngine;

public class ShipWrecks : MonoBehaviour
{
    public ShipWreck shipWreck;

    private void Start()
    {
        if (GameObject.Find(shipWreck.Data.type) != null)
        {
            Instantiate(GameObject.Find(shipWreck.Data.type), gameObject.transform, false);
        }
        else
        {
            if (!TypeExists())
            {
                shipWreck.Data.type = Registry.INSTANCE.shipWreckTypes.types[new System.Random().Next(Registry.INSTANCE.shipWreckTypes.types.Length)].name;
            }
        }
        name = shipWreck.Data.name;
    }

    private bool TypeExists()
    {
        for (int i = 0; i < Registry.INSTANCE.shipWreckTypes.types.Length; i++)
        {
            GameObject typeWreck = Registry.INSTANCE.shipWreckTypes.types[i];
            if (typeWreck.name == shipWreck.Data.type)
            {
                return true;
            }
        }
        return false;
    }
}