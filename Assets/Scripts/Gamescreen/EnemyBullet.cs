using System;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public float x = 1;
    public float y = 1;
    public float damage = 0.25f;
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Registry.profile.Data.health -= damage;
            Registry.profile.Ship.Data.bodyDamage += damage * 2;
            Registry.profile.Ship.Data.gunDamage += damage * 1.25f;
            Registry.profile.Ship.Data.thrusterDamage += damage * 1.1f;
            Registry.profile.Ship.Data.engineDamage += damage * 1.6f;
        }
    }
}
