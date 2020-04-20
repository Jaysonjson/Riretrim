using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public int amount;
    public GameObject planetDummy;
    void Start()
    {
        for (int i = 1; i < amount; i++)
        {
            GameObject planet = Instantiate(planetDummy, gameObject.transform, false);
        }
    }
}
