using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSEnemy : MonoBehaviour
{
    public GameScreen gameScreen;
    public int percentageAddition;
    public float bulletSpeed = 0.5f;
    public GameObject bullet;
    public void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(bulletSpeed);
        StartCoroutine(Shoot());
        GameObject shotBullet = Instantiate(bullet, gameObject.transform);
        shotBullet.SetActive(true);
        shotBullet.transform.position = new Vector3(gameObject.transform.position.x + 0.25f, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
    }
    
    private void OnDestroy()
    {
        gameScreen.percentage += percentageAddition;
    }
    
}

