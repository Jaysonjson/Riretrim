using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipDMGProgressbar : MonoBehaviour
{
    public RectTransform thrusterProgress;
    public RectTransform gunProgress;
    public RectTransform engineProgress;
    public RectTransform bodyProgress;

    public TextMeshProUGUI thrusterProgressPercentage;
    public TextMeshProUGUI gunProgressPercentage;
    public TextMeshProUGUI engineProgressPercentage;
    public TextMeshProUGUI bodyProgressPercentage;
    
    public static RectTransform progressBar;
    public static ShipDMGProgressbar INSTANCE;
    private void Start()
    {
        progressBar = gameObject.GetComponent<RectTransform>();
        INSTANCE = this;
        UpdateBars();
    }
    public void UpdateBars()
    {
        thrusterProgress.sizeDelta = new Vector2((Ship.thrusterDamage / Ship.thrusterDamageMax) * progressBar.sizeDelta.x, progressBar.sizeDelta.y);
        gunProgress.sizeDelta = new Vector2((Ship.gunDamage / Ship.gunDamageMax) * progressBar.sizeDelta.x, progressBar.sizeDelta.y);
        engineProgress.sizeDelta = new Vector2((Ship.engineDamage / Ship.engineDamageMax) * progressBar.sizeDelta.x, progressBar.sizeDelta.y);
        bodyProgress.sizeDelta = new Vector2((Ship.bodyDamage / Ship.bodyDamageMax) * progressBar.sizeDelta.x, progressBar.sizeDelta.y);
        thrusterProgressPercentage.text = ((Ship.thrusterDamage / Ship.thrusterDamageMax) * 100).ToString("0.00") + "%";
        gunProgressPercentage.text = ((Ship.gunDamage / Ship.gunDamageMax) * 100).ToString("0.00") + "%";
        engineProgressPercentage.text = ((Ship.engineDamage / Ship.engineDamageMax) * 100).ToString("0.00") + "%";
        bodyProgressPercentage.text = ((Ship.bodyDamage / Ship.bodyDamageMax) * 100).ToString("0.00") + "%";
    }
}
