using System;
using UnityEngine;

public class RiretrimGameObject : MonoBehaviour
{ 
    public bool DestroyableByBullet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision! " + "_");
        if (DestroyableByBullet)
        {
            if (other.tag.Equals("Bullet"))
            {
                if (other.GetComponent<HealthObject>() != null)
                {
                    other.GetComponent<HealthObject>().health -= Registry.profile.Ship.Data.damage;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}