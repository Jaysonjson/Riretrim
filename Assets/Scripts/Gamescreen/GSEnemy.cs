using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSEnemy : MonoBehaviour
{
    public GameScreen gameScreen;
    public int percentageAddition;
    public float bulletSpeed = 0.5f;
    public float damage;
    public GameObject bulletHandler;
    public GameObject bullet;
    public void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(bulletSpeed);
        StartCoroutine(Shoot());
        bulletHandler.GetComponent<IEnemyBullet>().damage = damage;
        bulletHandler.GetComponent<IEnemyBullet>().Shoot(bullet, this);
    }
    
    private void OnDestroy()
    {
        gameScreen.percentage += percentageAddition;
    }
    
}

