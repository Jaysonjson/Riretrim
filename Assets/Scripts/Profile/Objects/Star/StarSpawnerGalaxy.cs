using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawnerGalaxy : MonoBehaviour
{
    public int amount;
    public GameObject starDummy;
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject star = Instantiate(starDummy, gameObject.transform, false);
            star.SetActive(true);
        }
    }
}
