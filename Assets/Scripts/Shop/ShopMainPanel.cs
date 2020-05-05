using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMainPanel : MonoBehaviour
{
    public Shop Shop;
    public GameObject Object;
    public GameObject XPCircle;
    public GameObject ShipNameText;
    public Button BuyOrSelectButton;
    public TextMeshProUGUI BuyOrSelectText;
    public void GetObject()
    {
        Object = Shop.ships[Shop.currentObject];
    }
    
    public void UpdateObject()
    {
        if (Object != null)
        {
            Destroy(Object);
        }
        GetObject();
        string name = Object.name;
        Object = Instantiate(Object, transform);
        Object.SetActive(true);
        Object.name = name;
        Object.transform.localScale = new Vector3(200, 200);
        ShopShip data = Object.GetComponent<ShopShip>();
        if (data.xp < Profile.ship_xp)
        {
            XPCircle.GetComponent<Image>().fillAmount = 1;
        }
        else
        {
            XPCircle.GetComponent<Image>().fillAmount = ((Profile.ship_xp) * 100 / data.xp) / 100;
        }

        ShipNameText.GetComponent<TextMeshProUGUI>().text = Object.name;
        BuyOrSelectButton.enabled = true;
        ShopShipData shipData = new ShopShipData();
        shipData.Load(Object.name);
        if (shipData.bought)
        {
            BuyOrSelectText.text = "Select";
            if (Ship.body.Equals(Object.name))
            {
                BuyOrSelectText.text = "Selected";
                BuyOrSelectButton.enabled = false;
            }
        }
        else
        {
            BuyOrSelectText.text = "Buy";
        }
    }
    private void OnMouseUp()
    {
       UpdateObject();
       Shop.ShopLeftPanel.UpdateObject();
       Shop.ShopRightPanel.UpdateObject();
    }
    
    public void onBuyOrSelectClick()
    {
        ShopShipData shipData = new ShopShipData();
        shipData.Load(Object.name);
        if (shipData.bought)
        {
            Ship.body = Object.name;
            BuyOrSelectText.text = "Selected";
        }
        else
        {
            shipData.bought = true;
            shipData.Save(Object.name);
            BuyOrSelectText.text = "Select";
        }
        Ship.Save();
    }
}
