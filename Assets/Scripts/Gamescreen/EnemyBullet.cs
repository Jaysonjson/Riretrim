﻿using System;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public float x = 1;
    public float y = 1;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            
        }
    }
}