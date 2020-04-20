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
        Profile.load();
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
            case Materials.TIN: text.text = Profile.tin_amount + ""; break;
            case Materials.COAL: text.text = Profile.coal_amount + ""; break;
            case Materials.GOLD: text.text = Profile.gold_amount + ""; break;
            case Materials.IRON: text.text = Profile.iron_amount + ""; break;
            case Materials.TITAN: text.text = Profile.titan_amount + ""; break;
            case Materials.BRONZE: text.text = Profile.bronze_amount + ""; break;
            case Materials.CARBON: text.text = Profile.carbon_amount + ""; break;
            case Materials.COPPER: text.text = Profile.copper_amount + ""; break;
            case Materials.NICKEL: text.text = Profile.nickel_amount + ""; break;
            case Materials.CRYSTAL: text.text = Profile.crystal_amount + ""; break;
            case Materials.TUNGSTEN: text.text = Profile.tungsten_amount + ""; break;
            case Materials.ALUMINIUM: text.text = Profile.aluminium_amount + ""; break;
            default: text.text = "UNDEFINED"; break;
         }
    }
}
