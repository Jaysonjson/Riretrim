using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MiningDrillData
{
    public Materials material;
    public MiningDrillData(MiningDrill miningDrill)
    {
        material = miningDrill.material;
    }
}
