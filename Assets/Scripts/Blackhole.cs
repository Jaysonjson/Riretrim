using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 otherDirection = other.transform.position - transform.position;
        float angle = Mathf.Atan2(otherDirection.y, otherDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        other.transform.position = Vector2.MoveTowards(other.transform.position, gameObject.transform.position, 0.1f);
    }
}
