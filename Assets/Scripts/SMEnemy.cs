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
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && other is BoxCollider2D)
        {
           // Registry.profile.Save();
            // Destroy(gameObject);
            //SceneManager.LoadScene("Gamescreen");
        }
        if (other.tag.Equals("EnemyCollider") && other is CircleCollider2D)
        {
            //gameObject.transform.LookAt(other.gameObject.transform);
            triggered = true;
        }
    }

    private void Update()
    {
        if (triggered)
        {
            Vector3 playerDirection = player.transform.position - transform.position;
            float angle = Mathf.Atan2(playerDirection.y,playerDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, 0.035f);
      }
    }
}
