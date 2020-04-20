using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject target;
    public float speed;
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
}
