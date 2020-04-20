using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMapBullet : MonoBehaviour
{
    public GameObject bulletDummy;
    public float bulletSpeed;
    void Update()
    {
        if(Input.GetKeyDown((KeyCode.Space)))
        {
            GameObject bullet = Instantiate(bulletDummy, transform.position, transform.rotation);
            bullet.transform.position = gameObject.transform.position;
            bullet.gameObject.SetActive(true);
        }
    }
}
