using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSun : MonoBehaviour
{
    void Start()
    {
        Star star = new Star();
        star.LoadUsingName(Profile.Data.current_solarsystem);
        if (star.secondSun)
        {
            GetComponent<Orbit>().enabled = true;
        }
        gameObject.transform.localScale = new Vector3(star.sunScale, star.sunScale, 1);
    }
}
