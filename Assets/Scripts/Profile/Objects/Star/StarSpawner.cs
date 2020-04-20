using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starObject;
    void Update()
    {
        System.Random random = new System.Random();
        if(random.Next(45) == 1)
        {
                GameObject star = Instantiate(starObject, gameObject.transform);
                star.SetActive(true);
                star.transform.position = new Vector3((float)(random.Next(-5, 5) + random.NextDouble()), 5, 0);
        }
    }
}
 