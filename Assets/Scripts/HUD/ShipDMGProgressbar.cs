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

    public static RectTransform ThrusterProgress;
    public static RectTransform GunProgress;
    public static RectTransform EngineProgress;
    public static RectTransform BodyProgress;

    public static TextMeshProUGUI ThrusterProgressPercentage;
    public static TextMeshProUGUI GunProgressPercentage;
    public static TextMeshProUGUI EngineProgressPercentage;
    public static TextMeshProUGUI BodyProgressPercentage;

    public static RectTransform progressBar;

    private void Start()
    {
        progressBar = gameObject.GetComponent<RectTransform>();
        ThrusterProgress = thrusterProgress;
        GunProgress = gunProgress;
        EngineProgress = engineProgress;
        BodyProgress = bodyProgress;

        ThrusterProgressPercentage = thrusterProgressPercentage;
        GunProgressPercentage = gunProgressPercentage;
        EngineProgressPercentage = engineProgressPercentage;
        BodyProgressPercentage = bodyProgressPercentage;
        UpdateBars();
    }
    public static void UpdateBars()
    {
        ThrusterProgress.sizeDelta = new Vector2((Ship.thrusterDamage / Ship.thrusterDamageMax) * progressBar.sizeDelta.x, progressBar.sizeDelta.y);
        GunProgress.sizeDelta = new Vector2((Ship.gunDamage / Ship.gunDamageMax) * progressBar.sizeDelta.x, progressBar.sizeDelta.y);
        EngineProgress.sizeDelta = new Vector2((Ship.engineDamage / Ship.engineDamageMax) * progressBar.sizeDelta.x, progressBar.sizeDelta.y);
        BodyProgress.sizeDelta = new Vector2((Ship.bodyDamage / Ship.bodyDamageMax) * progressBar.sizeDelta.x, progressBar.sizeDelta.y);
        ThrusterProgressPercentage.text = ((Ship.thrusterDamage / Ship.thrusterDamageMax) * 100).ToString("0.00") + "%";
        GunProgressPercentage.text = ((Ship.gunDamage / Ship.gunDamageMax) * 100).ToString("0.00") + "%";
        EngineProgressPercentage.text = ((Ship.engineDamage / Ship.engineDamageMax) * 100).ToString("0.00") + "%";
        BodyProgressPercentage.text = ((Ship.bodyDamage / Ship.bodyDamageMax) * 100).ToString("0.00") + "%";

    }
}
