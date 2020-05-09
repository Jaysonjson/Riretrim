using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletGroup;
    private bool ableToShoot = true;
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if (ableToShoot)
            {
                StartCoroutine(shootBullet());
            }
        }
    }
    public IEnumerator shootBullet ()
    {
        GameObject spawned_bullet = Instantiate(bullet, bulletGroup.transform);
        spawned_bullet.SetActive(true);
        spawned_bullet.transform.position = new Vector3(gameObject.transform.position.x + 0.25f, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
        GameObject spawned_bullet1 = Instantiate(bullet, bulletGroup.transform);
        spawned_bullet1.SetActive(true);
        spawned_bullet1.transform.position = new Vector3(gameObject.transform.position.x - 0.25f, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
        ableToShoot = false;
        yield return new WaitForSeconds(0.55f);
        ableToShoot = true;
    }
}
