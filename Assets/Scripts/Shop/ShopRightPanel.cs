using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRightPanel : MonoBehaviour
{
    public Shop Shop;
    public GameObject Object;
    public void GetObject()
    {
        if(Shop.currentObject < Shop.ships.Count - 1)
        {
            Object = Shop.ships[Shop.currentObject + 1];
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
        if(Shop.currentObject < Shop.ships.Count && Shop.currentObject != Shop.ships.Count - 1)
        {
            Shop.currentObject++;
        } else if(Shop.currentObject == Shop.ships.Count - 1)
        {
            Shop.currentObject = 0;
        }
        UpdateObject();
        Shop.ShopLeftPanel.UpdateObject();
        Shop.ShopMainPanel.UpdateObject();
    }
}
