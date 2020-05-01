using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopLeftPanel : MonoBehaviour
{
    public Shop Shop;
    public GameObject Object;

    public void GetObject()
    {
        if(Shop.currentObject != 0)
        {
            Object = Shop.ships[Shop.currentObject - 1];
        } else if(Shop.currentObject == 0)
        {
            Object = Shop.ships[Shop.ships.Length - 1];
        } else
        {
            Object = Shop.ships[0];
        }
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
    }
    private void OnMouseUp()
    {
        if(Shop.currentObject < Shop.ships.Length && Shop.currentObject != 0)
        {
            Shop.currentObject--;
        } else if(Shop.currentObject == 0)
        {
            Shop.currentObject = Shop.ships.Length - 1;
        }
        UpdateObject();
        Shop.ShopMainPanel.UpdateObject();
        Shop.ShopRightPanel.UpdateObject();
    }
}
