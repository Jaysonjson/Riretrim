using JetBrains.Annotations;
using System;
using UnityEngine;
public class DamagedShip : MonoBehaviour
{
    public Sprite[] sprites;
    public float health = 0f;
    public float maxHealth = 0f;
    public SpriteRenderer spriteRenderer;
    private HealthObject healthObject;
    private void Start()
    {
        if(GetComponent<HealthObject>() != null)
        {
            healthObject = GetComponent<HealthObject>();
            health = healthObject.health;
            maxHealth = healthObject.maxHealth;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void UpdateSprite()
    {

        if (healthObject != null)
        {
            health = healthObject.health;
            maxHealth = healthObject.maxHealth;
        }

        float sprite = (health / maxHealth) * sprites.Length;
        int spriteToChange = sprites.Length - ((int)Math.Round(sprite) - 1);
        spriteRenderer.sprite = sprites[spriteToChange];
    }
}

