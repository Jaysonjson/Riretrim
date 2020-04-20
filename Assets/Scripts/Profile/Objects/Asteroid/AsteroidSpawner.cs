using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public int amount;
    public static int amount_Static;
    public GameObject asteroidDummy;
    void Start()
    {
        amount_Static += amount;
        for (int i = 0; i < amount; i++)
        {
            GameObject asteroid = Instantiate(asteroidDummy, gameObject.transform, false);
            System.Random random = new System.Random();
            float scale = (float)(random.Next(1, 3) + random.NextDouble());
            asteroid.transform.localScale = new Vector3(scale, scale, scale);
            asteroid.transform.position = new Vector2(Random.Range(-175, 175) + 5, Random.Range(-75, 75) + 5);
            asteroid.GetComponent<Orbit>().speed = (float)(random.NextDouble());
            asteroid.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, (byte)(random.Next(75, 255)));
            CameraZoom.asteroids.Add(asteroid);
        }
    }
}
