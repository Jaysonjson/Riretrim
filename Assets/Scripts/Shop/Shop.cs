using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int currentObject = 0;
    public ShopMainPanel ShopMainPanel;
    public ShopLeftPanel ShopLeftPanel;
    public ShopRightPanel ShopRightPanel;
    public GameObject[] ships;

    private void Start()
    {
        ShopMainPanel.UpdateObject();
        ShopLeftPanel.UpdateObject();
        ShopRightPanel.UpdateObject();
    }
}
