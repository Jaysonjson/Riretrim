using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI CurrencyText;
    public int currentObject = 0;
    public ShopMainPanel ShopMainPanel;
    public ShopLeftPanel ShopLeftPanel;
    public ShopRightPanel ShopRightPanel;
    public List<GameObject> ships;

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

        CurrencyText.text = Registry.profile.Data.currency + "";
    }
}
