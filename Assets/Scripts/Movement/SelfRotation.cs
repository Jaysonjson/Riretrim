using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotation : MonoBehaviour
{
    public float speed;
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}
