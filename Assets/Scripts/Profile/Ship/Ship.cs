using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    public static float heatResistance = 1538f;

    public static float thrusterDamage = 0f;
    public static float engineDamage = 0f;
    public static float gunDamage = 0f;
    public static float bodyDamage = 0f;

    public static float thrusterDamageMax = 200f;
    public static float engineDamageMax = 200f;
    public static float gunDamageMax = 200f;
    public static float bodyDamageMax = 200f;

    public static string body = "PlayerDefault"; //PlayerDefault
    public static void Load()
    {
        ShipData data = ShipSave.Load();
        thrusterDamage = data.thrusterDamage;
        engineDamage = data.engineDamage;
        gunDamage = data.gunDamage;
        bodyDamage = data.bodyDamage;

        thrusterDamageMax = data.thrusterDamageMax;
        engineDamageMax = data.engineDamageMax;
        gunDamageMax = data.gunDamageMax;
        bodyDamageMax = data.bodyDamageMax;
        heatResistance = data.heatResistance;
        body = data.body;
    }

    public static void Save()
    {
        ShipSave.Save();
    }
}
