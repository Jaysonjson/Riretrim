using System;
using UnityEngine;
public class MaterialData : MonoBehaviour
{
    public Sprite[] materials;
    public static Sprite[] MaterialSprites;

    private void Start()
    {
        MaterialSprites = materials;
    }
}