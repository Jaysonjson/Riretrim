using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSun : MonoBehaviour
{
    
    void Start()
    {
        Star star = new Star();
        star.LoadUsingName(Profile.current_solarsystem);
        if(star.secondSun)
        {
            gameObject.SetActive(true);
        }
    }
}
