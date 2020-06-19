using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject target;
    public float speed = 0;
    void FixedUpdate()
    {
        transform.RotateAround(target.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
}
