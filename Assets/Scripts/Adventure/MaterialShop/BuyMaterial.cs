using System;
using System.Collections;
using System.Collections.Generic;
using Discord;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyMaterial : MonoBehaviour
{
    public GameObject buyButton;
    public GameObject sellButton;
    public GameObject plusButton;
    public GameObject minusButton;
    public GameObject amountField;
    public GameObject amountText;
    public TextMeshProUGUI priceText;
    public Materials material;
    private int amount;
    public int price;
    private int sellValue;
    private int materialAmount;

    private void Start()
    {
        UpdateMaterialAmount();
        sellValue = price / 2;
        priceText.text = "Buy: " + price + "\nSell: " + sellValue;
    }

    public void MinusButtonClick()
    {
        if (amount > 0)
        {
            amount--;
            UpdateAmount();
        }
    }

    public void PlusButtonClick()
    {
        amount++;
        UpdateAmount();
    }

    public void BuyButton()
    {
        if (Registry.profile.Data.currency >= amount * price)
        {
            Material.addMaterial(material, amount);
            Registry.profile.Data.currency -= amount * price;
            UpdateMaterialAmount();
        }
    }
    
    public void SellButton()
    {
        if (amount <= materialAmount)
        {
            Material.addMaterial(material, -amount);
            Registry.profile.Data.currency += amount * sellValue;
            UpdateMaterialAmount();
        }
        else
        {
            Material.addMaterial(material, -materialAmount);
            Registry.profile.Data.currency += materialAmount * sellValue;
            UpdateMaterialAmount();
        }
    }
    
    public void UpdateAmount()
    {
        amountField.GetComponent<TMP_InputField>().text = amount + "";
    }

    public void UpdateInputField()
    {
        //if (amount > 0)
        //{
        amount = Convert.ToInt32(amountField.GetComponent<TMP_InputField>().text);
        //}
        //else
       //{
        //    amountField.GetComponent<TMP_InputField>().text = "0";
        //}
    }

    public void UpdateMaterialAmount()
    {
        TextMeshProUGUI text = amountText.GetComponent<TextMeshProUGUI>();
        switch (material)
        {
            case Materials.TIN:
                materialAmount = Registry.profile.Data.tin_amount; break;
            case Materials.COAL: 
                materialAmount = Registry.profile.Data.coal_amount; break;
            case Materials.GOLD:
                materialAmount = Registry.profile.Data.gold_amount; break;
            case Materials.IRON:
                materialAmount = Registry.profile.Data.iron_amount; break;
            case Materials.TITAN: 
                materialAmount = Registry.profile.Data.titan_amount; break;
            case Materials.BRONZE: 
                materialAmount = Registry.profile.Data.bronze_amount; break;
            case Materials.CARBON: 
                materialAmount = Registry.profile.Data.carbon_amount; break;
            case Materials.COPPER: 
                materialAmount = Registry.profile.Data.copper_amount; break;
            case Materials.NICKEL: 
                materialAmount = Registry.profile.Data.nickel_amount; break;
            case Materials.CRYSTAL: 
                materialAmount = Registry.profile.Data.crystal_amount; break;
            case Materials.TUNGSTEN:
                materialAmount = Registry.profile.Data.tungsten_amount; break;
            case Materials.ALUMINIUM:
                materialAmount = Registry.profile.Data.aluminium_amount; break;
            default:
                materialAmount = 0; text.text = "UNDEFINED"; break;
         }

        text.text = materialAmount + "";
    }
}
