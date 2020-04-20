using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMapMovement : MonoBehaviour
{
    public float speed = 5F;
    public Rigidbody2D rb;
    public GameObject sunObject;
    public ParticleSystem particleSystem;
    public TextMeshProUGUI coordinatesText;
    public TextMeshProUGUI sunDistanceText;
    public RectTransform miniMap;
    Vector2 movement;
    void Update()
    {
        movement.y = 0;
        movement.x = 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) 
        {
            movement.y = Input.GetAxisRaw("Vertical");
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            movement.x = Input.GetAxisRaw("Horizontal");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            //miniMap.transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(0, 0, 90);
           // miniMap.transform.Rotate(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
           // miniMap.transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(0, 0, 270);
           // miniMap.transform.Rotate(0, 0, 270);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
           // miniMap.transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(0, 0, 180);
           //miniMap.transform.Rotate(0, 0, 180);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
           // miniMap.transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(0, 0, 45);
           // miniMap.transform.Rotate(0, 0, 45);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
           // miniMap.transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(0, 0, 145);
           // miniMap.transform.Rotate(0, 0, 145);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
           // miniMap.transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(0, 0, 215);
           // miniMap.transform.Rotate(0, 0, 215);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
           // miniMap.transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(0, 0, 325);
           // miniMap.transform.Rotate(0, 0, 325);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 5f;
            //particleSystem.Play();
            particleSystem.maxParticles = 20000;
            //particleSystem.enableEmission = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 5f;
            //particleSystem.Stop();
            particleSystem.maxParticles = 0;
            //StartCoroutine(ParticleDespawn());
        }
        coordinatesText.text = "X = " + rb.position.x + ", Y = " + rb.position.y;
        if (sunObject != null)
        {
            sunDistanceText.text = "Sun Distance: " + Vector2.Distance(rb.position, sunObject.transform.position);
        }
    }

    private void Start()
    {
       // particleSystem.Stop();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}

