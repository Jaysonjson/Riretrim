using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSun : MonoBehaviour
{
    
    void Start()
    {
        Star star = new Star();
        star.Load(Registry.profile.Data.current_solarsystem);
        if(star.Data.secondSun)
        {
            gameObject.SetActive(true);
        }
    }
}
