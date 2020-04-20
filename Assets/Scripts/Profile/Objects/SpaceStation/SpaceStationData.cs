using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SpaceStationData
{
    public float scale;
    public SpaceStationData(SpaceStation spaceStation)
    {
        scale = spaceStation.scale;
    }
}
