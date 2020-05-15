using System;
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
    public GameObject currency;
    public TextMeshProUGUI asteroidCountText;

    private void Start()
    {
        GetComponent<ShadowCaster2D>().enabled = Options.Data.AsteroidShadows;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            DropMaterials();
        }
    }

    private void OnBecameVisible()
    {
        foreach (var monoBehaviour in gameObject.GetComponents<MonoBehaviour>())
        {
            if (monoBehaviour != gameObject.GetComponent<ShadowCaster2D>())
            {
                monoBehaviour.enabled = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    private void OnBecameInvisible()
    {
        foreach (var monoBehaviour in gameObject.GetComponents<MonoBehaviour>())
        {
            if (monoBehaviour != gameObject.GetComponent<ShadowCaster2D>())
            {
                monoBehaviour.enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    private void DropMaterials()
    {
        System.Random random = new System.Random();
        for (int i = 0; i < random.Next(3); i++)
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

            if (random.Next(5) == 1)
            {
                GameObject currency_mat = Instantiate(currency, new Vector3(gameObject.transform.position.x + ((float)random.NextDouble() / 2), gameObject.transform.position.y + (float)random.NextDouble(), gameObject.transform.position.y), new Quaternion(0, 0, random.Next(360), 0), GameObject.Find("Materials").transform);
                currency_mat.SetActive(true);
                currency_mat.GetComponent<Currency>().amount = 1 + random.Next(3);
            }
        }
        Registry.profile.Data.ship_xp += (float)random.NextDouble();
    }

    private void OnDestroy()
    {
        Star star = new Star();
        star.Load(Registry.profile.Data.current_solarsystem);
        Debug.Log(star.Data.name + " / " + star.Data.asteroid_count);
        star.Data.asteroid_count--;
        star.Data.Save();
        Debug.Log("Decreased Asteroid Count to " + star.Data.asteroid_count + " from Solarsystem " + star.Data.name);
        asteroidCountText.text = star.Data.asteroid_count + "";
    }
}

