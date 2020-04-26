﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Asteroid : MonoBehaviour
{
    public GameObject[] materials;
    public GameObject gold;
    public GameObject crystal;
    public GameObject coal;
    public TextMeshProUGUI asteroidCountText;

    private void Start()
    {
        if (Options.AsteroidShadows)
        {
            GetComponent<ShadowCaster2D>().enabled = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            DropMaterials();
        }
    }

    private void DropMaterials()
    {
        System.Random random = new System.Random();
        // if (random.Next(3) == 1)
        //{
        for (int i = 0; i < random.Next(7); i++)
        {
            GameObject material = Instantiate(materials[random.Next(materials.Length)], gameObject.transform.position, new Quaternion(0, 0, random.Next(360), 0), GameObject.Find("Materials").transform);
            material.SetActive(true);
            material.transform.Rotate(0, 0, random.Next(360));
            if (random.Next(35) == 1)
            {
                GameObject gold_mat = Instantiate(gold, gameObject.transform.position, new Quaternion(0, 0, random.Next(360), 0), GameObject.Find("Materials").transform);
                gold_mat.SetActive(true);
                gold_mat.transform.Rotate(0, 0, random.Next(360));
            }
            if (random.Next(75) == 1)
            {
                GameObject crystal_mat = Instantiate(crystal, gameObject.transform.position, new Quaternion(0, 0, random.Next(360), 0), GameObject.Find("Materials").transform);
                crystal_mat.SetActive(true);
                crystal_mat.transform.Rotate(0, 0, random.Next(360));
            }
            if (random.Next(25) == 1)
            {
                GameObject coal_mat = Instantiate(coal, gameObject.transform.position, new Quaternion(0, 0, random.Next(360), 0), GameObject.Find("Materials").transform);
                coal_mat.SetActive(true);
                coal_mat.transform.Rotate(0, 0, random.Next(360));
            }
                // material.GetComponent<Rigidbody2D>().AddForce(material.transform.up * 0.1f);
        }
            //int starIndex = Array.IndexOf(Galaxy.stars.ToArray(), Profile.current_solarsystem);
          // Star star = Stars.GetStar(starIndex);
            Star star = new Star();
            star.LoadUsingName(Profile.current_solarsystem);
            //star.load(starIndex);
            Debug.Log(star.sname + " / " + star.asteroid_count);
            star.asteroid_count--;
            //References.stars.Where(References.stars[starIndex](true)).Select(u => { u.asteroid_count = star.asteroid_count; return u; }).ToList();
            star.SaveAsStar();
            Debug.Log("Decreased Asteroid Count to " + star.asteroid_count + " from Solarsystem " + star.sname);
            asteroidCountText.text = star.asteroid_count + "";
        //  }
    }
}

