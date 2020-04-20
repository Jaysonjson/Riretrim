using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objects;
    private void Update()
    {
        System.Random random = new System.Random();
        if (random.Next(3) == 1)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                if (random.Next((int)Enum.Parse(typeof(SpawnChance), objects[i].name.ToUpper())) == 1)
                {
                    GameObject spawnedObject = Instantiate(objects[i], gameObject.transform);
                    spawnedObject.SetActive(true);
                    spawnedObject.transform.position = new Vector3((float)(random.Next(-4, 4) + random.NextDouble()), 5, 0);
                }
            }
        }
    }
       
    public enum SpawnChance {
        ZENIN = 525,
        CENT = 425,
    }
}
