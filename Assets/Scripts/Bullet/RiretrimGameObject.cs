using System;
using UnityEngine;

public class RiretrimGameObject : MonoBehaviour
{ 
    public bool DestroyableByBullet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (DestroyableByBullet)
        {
            if (other.tag.Equals("Bullet"))
            {
                if (GetComponent<HealthObject>() != null)
                {
                    GetComponent<HealthObject>().health -= Registry.profile.Ship.Data.damage;
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}