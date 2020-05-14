using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    public static int moonAmount = 0;
    public AsteroidSpawner asteroidSpawner;
    public PlanetSpawner planetSpawner;
    public ShipWreckSpawner ShipWreckSpawner;
    public TextMeshProUGUI currencyAmount;
    public TextMeshProUGUI currencyName;
    public GameObject UI;
    public Image fuelCircle;
    public Image energyCircle;
    public static SpaceMap INSTANCE;
    public CanvasScaler CanvasScaler;
    public Image circleMiniMap;
    public Image squareMiniMap;
    public Image minimapBar;
    public GameObject player;
    void Start()
    {
        INSTANCE = this;
        Registry.profile.Load();
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
        
        Star star = new Star();
        star.Load(Registry.profile.Data.current_solarsystem);
        asteroidSpawner.amount = star.Data.asteroid_count;
        planetSpawner.amount = star.Data.planet_count;
        ShipWreckSpawner.amount = star.Data.shipwreck_count;
        currencyAmount.text = Registry.profile.Data.currency + "";
        currencyName.text = Registry.profile.Data.currency_name;
        asteroidCountText.text = star.Data.asteroid_count + "";
        planetCountText.text = (star.Data.planet_count + 1) + "";
        //CanvasScaler.scaleFactor = Options.Data.HUDScale;
        CanvasScaler.referenceResolution = new Vector2(Options.Data.HUDScale, 1080);
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.8f);
        Planets.LoadPlanets();
        if (MapOptions.Data.ShipWrecks)
        {
            ShipWrecks.LoadShipWrecks();
            for (int i = 0; i < References.shipwrecks.Count; i++)
            {
                GameObject shipWreck = Instantiate(GameObject.Find(ShipWrecks.GetShipWreck(i).Data.type), ShipWrecks.GetShipWreck(i).main.transform, false);
                Debug.Log("Instantiated ShipWreck: " + shipWreck.name);
            }
        }

        moonCountText.text = moonAmount + "";
        //yield return new WaitForSeconds(0.2f);
        //Moons.LoadMoons();
    }
    void OnApplicationQuit()
    {
        Registry.profile.Save();
        for (int i = 0; i < References.planets.Count; i++)
        {
            Planets.GetPlanet(i).Data.position_x = Planets.GetPlanet(i).planetBody.transform.position.x;
            Planets.GetPlanet(i).Data.position_y = Planets.GetPlanet(i).planetBody.transform.position.y;
            Planets.GetPlanet(i).Data.Save();
        }
    }
    public void updateMaterialText()
    {
        aluminiumText.text = Registry.profile.Data.aluminium_amount + "";
        bronzeText.text = Registry.profile.Data.bronze_amount + "";
        carbonText.text = Registry.profile.Data.carbon_amount + "";
        coalText.text = Registry.profile.Data.coal_amount + "";
        crystalText.text = Registry.profile.Data.crystal_amount + "";
        goldText.text = Registry.profile.Data.gold_amount + "";
        tinText.text = Registry.profile.Data.tin_amount + "";
        titanText.text = Registry.profile.Data.titan_amount + "";
        nickelText.text = Registry.profile.Data.nickel_amount + "";
        tungstenText.text = Registry.profile.Data.tungsten_amount + "";
        copperText.text = Registry.profile.Data.copper_amount + "";
        ironText.text = Registry.profile.Data.iron_amount + "";
        currencyAmount.text = Registry.profile.Data.currency + "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Galaxyscreen");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(UI.active)
            {
                UI.SetActive(false);
            } else
            {
                UI.SetActive(true);
            }
        }
        
        fuelCircle.fillAmount = Registry.profile.Ship.Data.fuel / Registry.profile.Ship.Data.fuelMax;
        energyCircle.fillAmount = Registry.profile.Ship.Data.energy / Registry.profile.Ship.Data.energyMax;
        minimapBar.fillAmount = (((player.GetComponent<PlayerMapMovement>().getDistanceToSun() - 8) / 125) - 1) / -1;
    }
}
