using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SMEnemy : MonoBehaviour
{
    public bool triggered;
    public GameObject player;
    public Rigidbody2D rb;
    public float speed = 0.01f;
    public float maxSpeed = 0.1f;
    public float acceleration = 0.0001f;
    private float __speed;

    private void Start()
    {
        __speed = speed;
        transform.rotation = Quaternion.AngleAxis(new System.Random().Next(360), Vector3.forward);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other is BoxCollider2D)
        {
            Registry.profile.Save();
            SceneManager.LoadScene("Gamescreen");
        }
        if (other.CompareTag("EnemyCollider") && other is CircleCollider2D)
        {
            triggered = true;
        }
    }

    private void Update()
    {
        if (triggered)
        {
            if(maxSpeed > speed)
            {
                speed += acceleration;
            }

            Vector3 playerDirection = player.transform.position - transform.position;
            float angle = Mathf.Atan2(playerDirection.y,playerDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, speed);

            StartCoroutine(giveUp());
      }
    }

    IEnumerator giveUp()
    {
        yield return new WaitForSeconds(30f);
        triggered = false;
        speed = __speed;
    }
}
