using System;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{

    public Image[] hearts;
    public static Image[] staticHeart;
    public GameObject emptyHeartObject;
    public ShipSprites ShipSprites; 
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public ShipMono ShipMono;
    private void Start()
    {
        if (GameObject.Find(Registry.profile.Ship.Data.body) != null)
        {
            ShipSprites = GameObject.Find(Registry.profile.Ship.Data.body).GetComponent<ShipSprites>();
        }
        else
        {
            if (ShipMono != null)
            {
                ShipSprites = ShipMono.Sprites;
            }
        }

        if (ShipSprites != null)
        {
            fullHeart = ShipSprites.Flight;
            emptyHeart = ShipSprites.Damaged;
            emptyHeartObject.GetComponent<Image>().sprite = ShipSprites.Damaged;
        }
    }

    private void Update()
    {
        staticHeart = hearts;
        if (Registry.profile.Data.health > Registry.profile.Data.hearts)
        {
            Registry.profile.Data.health = Registry.profile.Data.hearts;
        }
        /*
        if ((Registry.profile.Data.health + 0.5) % 1 == 0)
        {
            hearts[getLastHeart()].fillAmount = 0.5F;
            emptyHeartObject.transform.position = hearts[getLastHeart()].transform.position;
        }
        if ((Registry.profile.Data.health + 0.75) % 1 == 0)
        {
            hearts[getLastHeart()].fillAmount = 0.25F;
            emptyHeartObject.transform.position = hearts[getLastHeart()].transform.position;
        }
        if ((Registry.profile.Data.health + 0.25) % 1 == 0)
        {
            hearts[getLastHeart()].fillAmount = 0.75F;
            emptyHeartObject.transform.position = hearts[getLastHeart()].transform.position;
        }
        */
        hearts[getLastHeart()].fillAmount = 1 - ((Registry.profile.Data.hearts - Registry.profile.Data.health) % 1);
        emptyHeartObject.transform.position = hearts[getLastHeart()].transform.position; 
        
        for (int i = 0; i < hearts.Length; i++)
        {
            Image image = hearts[i].GetComponent<Image>();
            Color color = image.color;
            if (i < Registry.profile.Data.health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < Registry.profile.Data.hearts)
            {
                color = new Color(color.r, color.g, color.b, 1f);
            }
            else
            {
                color = new Color(image.color.r, color.g, color.b, 0.25f);
            }

            image.color = color;
        }
    }
    public int getLastHeart()
    {
        int lastHeart = -1;
        for (int i = 0; i < hearts.Length; i++)
            if (i < Registry.profile.Data.health)
            {
                hearts[i].sprite = fullHeart;
                lastHeart++;
            }
        return lastHeart;
    }
    public static void setHealth(float amount)
    {
        Registry.profile.Data.health = amount;
        for (int i = 0; i < staticHeart.Length; i++)
        {
            staticHeart[i].fillAmount = 1F;
        }
    }
}
