using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject planetDummy;
    void Start()
    {
        for (int i = 0; i < RiretrimUtility.GetStar(Registry.profile.Data.current_solarsystem).Data.planets.Count; i++)
        {
            GameObject planet = Instantiate(planetDummy, gameObject.transform, false);
            planet.GetComponent<PlanetMono>().body.GetComponent<Planets>().planet = RiretrimUtility.GetStar(Registry.profile.Data.current_solarsystem).Data.planets.ElementAt(i).Value;
            planet.SetActive(true);
        }
    }
}
