using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSun : MonoBehaviour
{
    void Start()
    {
        Star star = RiretrimUtility.GetStar(Registry.profile.Data.current_galaxy, Registry.profile.Data.current_solarsystem);
        if (star.Data.secondSun)
        {
            GetComponent<Orbit>().enabled = true;
        }
        gameObject.transform.localScale = new Vector3(star.Data.sunScale, star.Data.sunScale, 1);
    }
}
