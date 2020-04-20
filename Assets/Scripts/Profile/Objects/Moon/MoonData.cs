using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoonData
{
    public float scale;
    public MoonData(Moon moon)
    {
        scale = moon.scale;
    }
}
