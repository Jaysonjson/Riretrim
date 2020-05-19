using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SMEnemy : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Registry.profile.Save();
            // Destroy(gameObject);
            SceneManager.LoadScene("Gamescreen");
        }
    }
}
