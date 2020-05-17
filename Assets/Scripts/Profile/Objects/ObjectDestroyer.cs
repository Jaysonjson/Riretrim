using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject[] ignore;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision: " + collision.gameObject);

        if (!Array.Exists(ignore, element => element == collision.gameObject) && collision.gameObject.tag != "MaterialCollision")
        {
            Debug.Log("Destroyed: " + collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
