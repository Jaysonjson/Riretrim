using System;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class Currency : MonoBehaviour
{
    Random Random = new Random();
    public TextMeshPro text;
    public int amount;
    private void Start()
    {
        text.text = amount + "";
        GetComponent<Rigidbody2D>().AddForce(transform.up * (float)Random.NextDouble());
    }

    private void Update()
    {
        transform.Rotate(0, 0, 0.05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Registry.profile.Data.currency += amount;
        Destroy(gameObject);
    }
}
