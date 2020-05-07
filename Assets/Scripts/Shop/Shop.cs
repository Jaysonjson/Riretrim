using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public int currentObject = 0;
    public ShopMainPanel ShopMainPanel;
    public ShopLeftPanel ShopLeftPanel;
    public ShopRightPanel ShopRightPanel;
    public GameObject[] ships;

    private void Start()
    {
        //Registry.profile.Load();
        ShopMainPanel.UpdateObject();
        ShopLeftPanel.UpdateObject();
        ShopRightPanel.UpdateObject();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("SpaceMap");
        }
    }
}
