using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ShipData
{
    public float thrusterDamage;
    public float engineDamage;
    public float gunDamage;
    public float bodyDamage;

    public float thrusterDamageMax;
    public float engineDamageMax;
    public float gunDamageMax;
    public float bodyDamageMax;

    public float heatResistance;
    public ShipData()
    {
        thrusterDamage = Ship.thrusterDamage;
        engineDamage = Ship.engineDamage;
        gunDamage = Ship.gunDamage;
        bodyDamage = Ship.bodyDamage;

        thrusterDamageMax = Ship.thrusterDamageMax;
        engineDamageMax = Ship.engineDamageMax;
        gunDamageMax = Ship.gunDamageMax;
        bodyDamageMax = Ship.bodyDamageMax;
        heatResistance = Ship.heatResistance;
    }
}
