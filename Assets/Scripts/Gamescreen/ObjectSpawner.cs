using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public ObjectSpawnerEntry[] objects;
    public System.Random random = new System.Random();

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        if (random.Next(4) == 1)
        {
            if (objects[0].spawn)
            {
                GameObject spawnedObject = Instantiate(objects[0].gameObject, gameObject.transform);
                spawnedObject.SetActive(true);
                spawnedObject.transform.position = new Vector3((float)(random.Next(-4, 4) + random.NextDouble()), 4.5f, 0);
            }
        }
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
            if (objects[i].spawn)
            {
                if (random.Next(objects[i].spawnChance) == 1)
                {
                    GameObject spawnedObject = Instantiate(objects[i].gameObject, gameObject.transform);
                    spawnedObject.SetActive(true);
                    spawnedObject.transform.position = new Vector3((float)(random.Next(-4, 4) + random.NextDouble()), 4.5f, 0);
                    break;
                }
            }
        }
        yield return new WaitForSeconds(1.2f);
        StartCoroutine(Spawn());
    }
/*
    public enum SpawnChance {
        ZENIN = 50,
        CENT = 25,
    }
    */
}
