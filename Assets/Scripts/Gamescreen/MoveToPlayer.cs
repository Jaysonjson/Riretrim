using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public float speed = 0.0002f;
    public bool sizeChange;
    private float size = 0f;
    
    private void Start()
    {
        size = gameObject.transform.localScale.x;
    }

    private void Update()
    {
        speed += 0.0001f;
        if (sizeChange && size > 0.1)
        {
            size -= 0.0001f;
            transform.localScale = new Vector3(size, size, transform.localScale.z);
        }

        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, speed);
    }
}
