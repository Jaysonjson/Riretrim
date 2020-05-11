using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpaceMap : MonoBehaviour
{
    private void Start()
    {
        //gameObject.GetComponent<Rigidbody2D>().velocity = (GameObject.Find("Player").transform.forward).normalized * GameObject.Find("Player").GetComponent<SpaceMapBullet>().bulletSpeed;
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * GameObject.Find("Player").GetComponent<SpaceMapBullet>().bulletSpeed);
        StartCoroutine(Despawn());
    }

    private void Update()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.05f, gameObject.transform.localScale.y -  0.05f, 1);
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
