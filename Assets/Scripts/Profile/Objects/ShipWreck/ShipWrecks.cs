using System;
using UnityEngine;

public class ShipWrecks : MonoBehaviour
{
    public ShipWreck shipWreck;
    
    private void Start()
    {
        Instantiate(GameObject.Find(shipWreck.Data.type), gameObject.transform, false);
        name = shipWreck.Data.name;
       // addShipWreck(new ShipWreck(types[new System.Random().Next(types.Length)].name, gameObject));
    }
}