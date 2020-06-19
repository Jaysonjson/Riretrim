using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMovement : MonoBehaviour
{
    public float movement = 5f;
    public Directions direction;
    void FixedUpdate()
    {
        if (direction == Directions.DOWN)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - movement, transform.position.z);
        }
        if(direction == Directions.TOP)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + movement, transform.position.z);
        }
    }

    public enum Directions
    {
        TOP, DOWN, LEFT, RIGHT
    }
}
