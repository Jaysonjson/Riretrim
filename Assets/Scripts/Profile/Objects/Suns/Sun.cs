﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Sun : MonoBehaviour
{
    public GameObject[] glows;
    [SerializeField]
    Light2D[] light2d = null;
    void Start()
    {
        string path = Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + Registry.profile.Data.current_solarsystem + "/data.star";
        if (File.Exists(path))
        {
            StarData data = new StarData();
            data.Load(Registry.profile.Data.current_solarsystem);
            System.Random random = new System.Random();
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(data.color[0], data.color[1], data.color[2], 255);
            for (int i = 0; i < glows.Length; i++)
            {
                if (data.color[0] != 255 && data.color[1] != 255 && data.color[2] != 255)
                {
                    glows[i].GetComponent<SpriteRenderer>().color = new Color32((byte)(data.color[0] + random.Next(10)), (byte)(data.color[1] + random.Next(10)), (byte)(data.color[2] + random.Next(10)), (byte)(glows[i].GetComponent<SpriteRenderer>().color.a * 255));
                }
                glows[i].GetComponent<SpriteRenderer>().size *= 2.2f;
            }
            for (int i = 0; i < light2d.Length; i++)
            {
                light2d[i].color = new Color32(data.color[0], data.color[1], data.color[2], 255);
            }
        }
    }
}
