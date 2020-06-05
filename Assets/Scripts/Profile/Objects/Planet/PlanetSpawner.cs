using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject planetDummy;
    void Start()
    {
        for (int i = 0; i < RiretrimUtility.G; i++)
        {
            GameObject star = Instantiate(starDummy, gameObject.transform, false);
            star.GetComponent<Stars>().star = RiretrimUtility.GetGalaxy(Registry.profile.Data.current_galaxy).Data.stars.ElementAt(i).Value;
            star.SetActive(true);
        }
    }
}
