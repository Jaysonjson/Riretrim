using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMainPanel : MonoBehaviour
{
    public Shop Shop;
    public GameObject Object;
    public GameObject XPCircle;
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
        Object = Instantiate(Object, transform);
        Object.SetActive(true);
        Object.transform.localScale = new Vector3(200, 200);
        //XPCircle.GetComponent<Image>().fillAmount = ((Profile.ship_xp * 100) / Object.GetComponent<ShopShip>().xp) / 100;
        ShopShip data = Object.GetComponent<ShopShip>();
        if (data.xp < Profile.ship_xp)
        {
            XPCircle.GetComponent<Image>().fillAmount = 1;
        }
        else
        {
            XPCircle.GetComponent<Image>().fillAmount = (float) ((Profile.ship_xp) * 100 / data.xp) / 100;
        }
    }
    private void OnMouseUp()
    {
       UpdateObject();
       Shop.ShopLeftPanel.UpdateObject();
       Shop.ShopRightPanel.UpdateObject();
    }
}
