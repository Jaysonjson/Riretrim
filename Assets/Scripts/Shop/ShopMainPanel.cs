using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMainPanel : MonoBehaviour
{
    public Shop Shop;
    public GameObject Object;

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
        Object.GetComponent<SpriteRenderer>().size *= 2;
    }
    private void OnMouseUp()
    {
       UpdateObject();
       Shop.ShopLeftPanel.UpdateObject();
       Shop.ShopRightPanel.UpdateObject();
    }
}
