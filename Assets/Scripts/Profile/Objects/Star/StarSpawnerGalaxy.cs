using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawnerGalaxy : MonoBehaviour
{
    public int amount;
    public GameObject starDummy;
    void Start()
    {
        for (int i = 0; i < Registry.profile.Data.galaxies.Count; i++)
        {
            GameObject star = Instantiate(starDummy, gameObject.transform, false);
            star.GetComponent<Stars>().star = RiretrimUtility.GetGalaxy(Registry.profile.Data.current_galaxy).Data.stars.ElementAt(i).Value;
            star.SetActive(true);
        }
    }
}
