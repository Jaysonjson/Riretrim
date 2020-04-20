﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GalaxyMap : MonoBehaviour
{

    public GameObject galaxyText;
    
    void Start()
    {
        References.stars.Clear();
        galaxyText.GetComponent<TextMeshProUGUI>().text = Profile.current_galaxy;
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Loading Stars..");
        Stars.LoadStars();
    }
    void OnApplicationQuit()
    {
        Profile.save();
       // for (int i = 0; i < References.planets.Count; i++)
       // {
           //Stars.GetPlanet(i).position_x = Planets.GetPlanet(i).planet.transform.position.x;
            //Planets.GetPlanet(i).position_y = Planets.GetPlanet(i).planet.transform.position.y;
           // Planets.GetPlanet(i).save(i);
      //  }
    }
}
