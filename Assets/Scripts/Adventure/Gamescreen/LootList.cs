using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootList : MonoBehaviour
{
    public Loot[] lootList;
    public int lootAmount;
    public int currencyAmount;
    public int minCurrencyAmount;
    public int xpAmount;
    public GameObject currency;
    public bool dropLoot = true;
    private System.Random random = new System.Random();
    private void OnDestroy()
    {
        if (dropLoot)
        {
            Vector3 position = gameObject.transform.position;
            GameObject currencyDrop = Instantiate(currency);
            currencyDrop.SetActive(true);
            currencyDrop.transform.position = position;
            currencyDrop.GetComponent<Currency>().amount = random.Next(minCurrencyAmount, currencyAmount);
            Registry.profile.Data.ship_xp += random.Next(xpAmount);
            for (int i = 0; i < lootAmount; i++)
            {
                for (int j = 0; j < lootList.Length; j++)
                {
                    if (random.Next(lootList[j].dropChance) == 1)
                    {
                        GameObject lootDrop = Instantiate(lootList[j].gameObject);
                        lootDrop.transform.position = position;
                        lootDrop.SetActive(true);
                        if (lootList[j].GetComponent<Currency>() != null)
                        {
                            lootList[j].GetComponent<Currency>().amount = random.Next(minCurrencyAmount, currencyAmount) * 3;
                        }
                    }
                }
            }
        }
    }
}
