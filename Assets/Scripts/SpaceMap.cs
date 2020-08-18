using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceMap : MonoBehaviour
{
    public GameObject galaxyText;
    public GameObject solarSystemText;
    public TextMeshProUGUI aluminiumText;
    public TextMeshProUGUI bronzeText;
    public TextMeshProUGUI carbonText;
    public TextMeshProUGUI coalText;
    public TextMeshProUGUI crystalText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI tinText;
    public TextMeshProUGUI titanText;
    public TextMeshProUGUI tungstenText;
    public TextMeshProUGUI nickelText;
    public TextMeshProUGUI copperText;
    public TextMeshProUGUI ironText;
    public TextMeshProUGUI asteroidCountText;
    public TextMeshProUGUI moonCountText;
    public TextMeshProUGUI planetCountText;
    public TextMeshProUGUI enemyCountText;
    public TextMeshProUGUI orbit;
    public static int moonAmount = 0;
    public AsteroidSpawner asteroidSpawner;
    public TextMeshProUGUI currencyAmount;
    public TextMeshProUGUI currencyName;
    public TextMeshProUGUI autoSaveText;
    public GameObject UI;
    public Image fuelCircle;
    public Image energyCircle;
    public static SpaceMap INSTANCE;
    public CanvasScaler CanvasScaler;
    public Image circleMiniMap;
    public Image squareMiniMap;
    private Image minimapBar;
    public GameObject player;
    private System.Random random = new System.Random();
    public Star star;
    void Start()
    {
        INSTANCE = this;
        Registry.profile.Load();
        star = RiretrimUtility.GetStar(Registry.profile.Data.current_solarsystem);
        galaxyText.GetComponent<TextMeshProUGUI>().text = Registry.profile.Data.current_galaxy;
        solarSystemText.GetComponent<TextMeshProUGUI>().text = Registry.profile.Data.current_solarsystem;

        updateMaterialText();

        if (Options.Data.MiniMapHud == MiniMapHUD.CIRCLE)
        {
            squareMiniMap.gameObject.SetActive(false);
            minimapBar = circleMiniMap;
        }

        if (Options.Data.MiniMapHud == MiniMapHUD.SQUARE)
        {
            circleMiniMap.gameObject.SetActive(false);
            circleMiniMap.gameObject.transform.parent.gameObject.SetActive(false);
            minimapBar = squareMiniMap;
        }

        asteroidSpawner.amount = star.Data.asteroid_count;
        currencyAmount.text = Registry.profile.Data.currency + "";
        currencyName.text = Registry.profile.Data.currency_name;
        asteroidCountText.text = star.Data.asteroid_count + "";
        planetCountText.text = (star.Data.planets.Count) + "";
        enemyCountText.text = star.Data.enemy_count + "";
        moonCountText.text = RiretrimUtility.GetMoonAmountInStar(star) + "";
        //CanvasScaler.scaleFactor = Options.Data.HUDScale;
        CanvasScaler.referenceResolution = new Vector2(Options.Data.HUDScale, 1080);
        if (Options.Data.AutoSave)
        {
            StartCoroutine(autoSave());
        }
    }

    IEnumerator autoSave()
    {
        yield return new WaitForSeconds(600f);
        autoSaveText.gameObject.SetActive(true);
        Registry.profile.Save();
        Registry.adventureMap.Save();
        yield return new WaitForSeconds(2f);
        autoSaveText.gameObject.SetActive(false);
        StartCoroutine(autoSave());
    }

    void OnApplicationQuit()
    {
        Registry.profile.Save();
        Registry.adventureMap.Save();
    }

    public void updateMaterialText()
    {
        aluminiumText.text = Registry.profile.Data.aluminium_amount.ToString();
        bronzeText.text = Registry.profile.Data.bronze_amount.ToString();
        carbonText.text = Registry.profile.Data.carbon_amount.ToString();
        coalText.text = Registry.profile.Data.coal_amount.ToString();
        crystalText.text = Registry.profile.Data.crystal_amount.ToString();
        goldText.text = Registry.profile.Data.gold_amount.ToString();
        tinText.text = Registry.profile.Data.tin_amount.ToString();
        titanText.text = Registry.profile.Data.titan_amount.ToString();
        nickelText.text = Registry.profile.Data.nickel_amount.ToString();
        tungstenText.text = Registry.profile.Data.tungsten_amount.ToString();
        copperText.text = Registry.profile.Data.copper_amount.ToString();
        ironText.text = Registry.profile.Data.iron_amount.ToString();
        currencyAmount.text = Registry.profile.Data.currency.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Galaxyscreen");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("Gamescreen");
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (UI.activeSelf)
            {
                UI.SetActive(false);
            }
            else
            {
                UI.SetActive(true);
            }
        }
        fuelCircle.fillAmount = Registry.profile.Ship.Data.fuel / Registry.profile.Ship.Data.fuelMax;
        energyCircle.fillAmount = Registry.profile.Ship.Data.energy / Registry.profile.Ship.Data.energyMax;
        minimapBar.fillAmount = (((player.GetComponent<PlayerMapMovement>().getDistanceToSun() - 8) / 125) - 1) / -1;
        orbit.text = Registry.Language.orbiting.Replace("%S", player.GetComponent<Orbit>().target.name);
        if (random.Next(1500) == 1)
        {
            star.Data.enemy_count++;
        }
    }
}
