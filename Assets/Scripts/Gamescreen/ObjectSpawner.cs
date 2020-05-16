using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public ObjectSpawnerEntry[] objects;
    public System.Random random = new System.Random();
    private void Update()
    {
        if (random.Next(24) == 1)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                /*
                if (random.Next((int) Enum.Parse(typeof(SpawnChance), objects[i].name.ToUpper())) == 1)
                {
                        GameObject spawnedObject = Instantiate(objects[i], gameObject.transform);
                        spawnedObject.SetActive(true);
                        spawnedObject.transform.position = new Vector3((float) (random.Next(-4, 4) + random.NextDouble()), 4.5f, 0); 
                        break;
                }
                */
                if (random.Next(objects[i].spawnChance) == 1)
                {
                    GameObject spawnedObject = Instantiate(objects[i].gameObject, gameObject.transform);
                    spawnedObject.SetActive(true);
                    spawnedObject.transform.position = new Vector3((float)(random.Next(-4, 4) + random.NextDouble()), 4.5f, 0);
                    break;
                }
            }
        }
    }
       
    public enum SpawnChance {
        ZENIN = 50,
        CENT = 25,
    }
}
