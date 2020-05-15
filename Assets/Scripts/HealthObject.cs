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
        healthBar.transform.parent.gameObject.SetActive(!(health >= maxHealth));
        if (healthBar != null)
        {
            healthBar.GetComponent<Image>().fillAmount = health / maxHealth;
        }

        if (health <= 0 && destroy)
        {
            Destroy(gameObject);
        }

        if (health < maxHealth)
        {
            health += regeneration;
        }
    }
}
