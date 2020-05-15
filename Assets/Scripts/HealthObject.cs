using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthObject : MonoBehaviour
{
    public GameObject healthBar;
    public float health;
    public float maxHealth;
    public float regeneration;
    public bool destroy;
    private void Update()
    {
        if (healthBar != null)
        {
            healthBar.GetComponent<Image>().fillAmount = health / maxHealth;
        }

        if (health <= 0 && destroy)
        {
            Destroy(gameObject);
        }
    }
}
