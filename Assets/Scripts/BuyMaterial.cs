using System;
using System.Collections;
using System.Collections.Generic;
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
    public Materials material;
    private int amount;


    private void Start()
    {
        UpdateMaterialAmount();
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
        Material.addMaterial(material, amount);
        UpdateMaterialAmount();
    }
    
    public void SellButton()
    {
        Material.addMaterial(material, -amount);
        UpdateMaterialAmount();
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
            case Materials.TIN: text.text = Registry.profile.Data.tin_amount + ""; break;
            case Materials.COAL: text.text = Registry.profile.Data.coal_amount + ""; break;
            case Materials.GOLD: text.text = Registry.profile.Data.gold_amount + ""; break;
            case Materials.IRON: text.text = Registry.profile.Data.iron_amount + ""; break;
            case Materials.TITAN: text.text = Registry.profile.Data.titan_amount + ""; break;
            case Materials.BRONZE: text.text = Registry.profile.Data.bronze_amount + ""; break;
            case Materials.CARBON: text.text = Registry.profile.Data.carbon_amount + ""; break;
            case Materials.COPPER: text.text = Registry.profile.Data.copper_amount + ""; break;
            case Materials.NICKEL: text.text = Registry.profile.Data.nickel_amount + ""; break;
            case Materials.CRYSTAL: text.text = Registry.profile.Data.crystal_amount + ""; break;
            case Materials.TUNGSTEN: text.text = Registry.profile.Data.tungsten_amount + ""; break;
            case Materials.ALUMINIUM: text.text = Registry.profile.Data.aluminium_amount + ""; break;
            default: text.text = "UNDEFINED"; break;
         }
    }
}
