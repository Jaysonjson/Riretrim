﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stars : MonoBehaviour
{
    public GameObject text;
    public float scale;

    public Star AddStar(Star star)
    {
        star.index = References.stars.Count;
        References.stars.Add(star);
        return star;
    }

    public static Star GetStar(int index)
    {
        return References.stars[index];
    }

    void Start()
    {
        scale = gameObject.transform.localScale.x;
        AddStar(new Star(text, gameObject));
    }

    public static void LoadStars()
    {
        for (int i = 0; i < References.stars.Count; i++)
        {
            GetStar(i).Generate();
            GetStar(i).Save(i);
        }
    }

    public void Click()
    {
        Profile.Data.current_solarsystem = gameObject.name;
        Profile.Data.latest_solarSystem = gameObject.name;
        Profile.Save();
        Star star = new Star();
        star.LoadUsingName(Profile.Data.current_solarsystem);
        star.visited = true;
        star.visitTime = DateTime.Now;
        star.SaveAsStar();
        SceneManager.LoadScene("SpaceMap");
    }

    public void sizeAdjust()
    {
        gameObject.transform.localScale = new Vector3(scale * 2, scale * 2, 1);
    }

    public void sizeDecrease()
    {
        gameObject.transform.localScale = new Vector3(scale, scale, 1);
    }
}
