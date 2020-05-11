using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Stars : MonoBehaviour
{
    public GameObject text;
    public float scale;
    public Light2D[] lights;

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
        AddStar(new Star(text, gameObject, lights));
    }

    public static void LoadStars()
    {
        for (int i = 0; i < References.stars.Count; i++)
        {
            GetStar(i).Generate();
            GetStar(i).Save(GetStar(i).Data.name);
        }
    }

    public void Click()
    {
        Registry.profile.Data.current_solarsystem = gameObject.name;
        Registry.profile.Data.latest_solarSystem = gameObject.name;
        Registry.profile.Save();
        Star star = new Star();
        star.Data.Load(Registry.profile.Data.current_solarsystem);
        star.Data.visited = true;
        star.Data.visitTime = star.Data.visitTime.convertToJsonDateTime(DateTime.Now);
        star.Data.Save();
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
