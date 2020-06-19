using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHorizontalMovement : MonoBehaviour
{
    public float speed = 5F;
    public Rigidbody2D rb;
    Vector2 movement;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
