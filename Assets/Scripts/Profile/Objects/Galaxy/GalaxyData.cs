using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GalaxyData
{
    public List<string> stars;
    public GalaxyData()
    {
        stars = Galaxy.stars;
    }
}

