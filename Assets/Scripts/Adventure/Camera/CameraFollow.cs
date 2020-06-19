using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothness;
    private Vector2 velocity;
    void FixedUpdate()
    {
        float x = Mathf.SmoothDamp(transform.position.x, player.position.x, ref velocity.x, smoothness);
        float y = Mathf.SmoothDamp(transform.position.y, player.position.y, ref velocity.y, smoothness);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
