using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{

    public Image[] hearts;
    public static Image[] staticHeart;
    public GameObject emptyHeartObject;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private void Update()
    {
        staticHeart = hearts;
        if (Profile.Data.health > Profile.Data.hearts)
        {
            Profile.Data.health = Profile.Data.hearts;
        }
        if ((Profile.Data.health + 0.5) % 1 == 0)
        {
            hearts[getLastHeart()].fillAmount = 0.5F;
            emptyHeartObject.transform.position = hearts[getLastHeart()].transform.position;
        }
        if ((Profile.Data.health + 0.75) % 1 == 0)
        {
            hearts[getLastHeart()].fillAmount = 0.75F;
            emptyHeartObject.transform.position = hearts[getLastHeart()].transform.position;
        }
        if ((Profile.Data.health + 0.25) % 1 == 0)
        {
            hearts[getLastHeart()].fillAmount = 0.25F;
            emptyHeartObject.transform.position = hearts[getLastHeart()].transform.position;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Profile.Data.health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < Profile.Data.hearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public int getLastHeart()
    {
        int lastHeart = -1;
        for (int i = 0; i < hearts.Length; i++)
            if (i < Profile.Data.health)
            {
                hearts[i].sprite = fullHeart;
                lastHeart++;
            }
        return lastHeart;
    }
    public static void setHealth(float amount)
    {
        Profile.Data.health = amount;
        for (int i = 0; i < staticHeart.Length; i++)
        {
            staticHeart[i].fillAmount = 1F;
        }
    }
}
