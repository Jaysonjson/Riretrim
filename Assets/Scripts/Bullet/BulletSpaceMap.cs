using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpaceMap : MonoBehaviour
{
    void Start()
    {
        //gameObject.GetComponent<Rigidbody2D>().velocity = (GameObject.Find("Player").transform.forward).normalized * GameObject.Find("Player").GetComponent<SpaceMapBullet>().bulletSpeed;
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * GameObject.Find("Player").GetComponent<SpaceMapBullet>().bulletSpeed);
        StartCoroutine(Despawn());
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
