using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletGroup;
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            GameObject spawned_bullet = Instantiate(bullet, bulletGroup.transform);
            spawned_bullet.SetActive(true);
            spawned_bullet.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
        }
    }
}
