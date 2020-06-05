using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSun : MonoBehaviour
{
    
    void Start()
    {
        Star star = RiretrimUtility.GetStar(Registry.profile.Data.current_galaxy, Registry.profile.Data.current_solarsystem);
        if(star.Data.secondSun)
        {
            gameObject.SetActive(true);
        }
    }
}
