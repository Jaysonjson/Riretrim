using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceMap : MonoBehaviour
{
    public GameObject galaxyText;
    public GameObject solarSystemText;

    public GameObject aluminiumText;
    public GameObject bronzeText;
    public GameObject carbonText;
    public GameObject coalText;
    public GameObject crystalText;
    public GameObject goldText;
    public GameObject tinText;
    public GameObject titanText;
    public GameObject tungstenText;
    public GameObject nickelText;
    public GameObject copperText;
    public GameObject ironText;
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

    public static TextMeshProUGUI aluminiumUIText;
    public static TextMeshProUGUI bronzeUIText;
    public static TextMeshProUGUI carbonUIText;
    public static TextMeshProUGUI coalUIText;
    public static TextMeshProUGUI crystalUIText;
    public static TextMeshProUGUI goldUIText;
    public static TextMeshProUGUI tinUIText;
    public static TextMeshProUGUI titanUIText;
    public static TextMeshProUGUI tungstenUIText;
    public static TextMeshProUGUI nickelUIText;
    public static TextMeshProUGUI copperUIText;
    public static TextMeshProUGUI ironUIText;

    
    
    void Start()
    {
        Registry.profile.Load();
        galaxyText.GetComponent<TextMeshProUGUI>().text = Registry.profile.Data.current_galaxy;
        solarSystemText.GetComponent<TextMeshProUGUI>().text = Registry.profile.Data.current_solarsystem;

        aluminiumUIText = aluminiumText.GetComponent<TextMeshProUGUI>();
        bronzeUIText = bronzeText.GetComponent<TextMeshProUGUI>();
        carbonUIText = carbonText.GetComponent<TextMeshProUGUI>();
        coalUIText = coalText.GetComponent<TextMeshProUGUI>();
        crystalUIText = crystalText.GetComponent<TextMeshProUGUI>();
        goldUIText = goldText.GetComponent<TextMeshProUGUI>();
        tinUIText = tinText.GetComponent<TextMeshProUGUI>();
        titanUIText = titanText.GetComponent<TextMeshProUGUI>();
        nickelUIText = nickelText.GetComponent<TextMeshProUGUI>();
        tungstenUIText = tungstenText.GetComponent<TextMeshProUGUI>();
        copperUIText = copperText.GetComponent<TextMeshProUGUI>();
        ironUIText = ironText.GetComponent<TextMeshProUGUI>();

        updateMaterialText();

        Star star = new Star();
        star.Load(Registry.profile.Data.current_solarsystem);
        asteroidSpawner.amount = star.Data.asteroid_count;
        planetSpawner.amount = star.Data.planet_count;
        ShipWreckSpawner.amount = star.Data.shipwreck_count;
        currencyAmount.text = Registry.profile.Data.currency + "";
        currencyName.text = Registry.profile.Data.currency_name;
        asteroidCountText.text = star.Data.asteroid_count + "";
        planetCountText.text = star.Data.planet_count + "";
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
            Planets.GetPlanet(i).position_x = Planets.GetPlanet(i).planetBody.transform.position.x;
            Planets.GetPlanet(i).position_y = Planets.GetPlanet(i).planetBody.transform.position.y;
            Planets.GetPlanet(i).save(i);
        }
    }
    public static void updateMaterialText()
    {
        aluminiumUIText.text = Registry.profile.Data.aluminium_amount + "";
        bronzeUIText.text = Registry.profile.Data.bronze_amount + "";
        carbonUIText.text = Registry.profile.Data.carbon_amount + "";
        coalUIText.text = Registry.profile.Data.coal_amount + "";
        crystalUIText.text = Registry.profile.Data.crystal_amount + "";
        goldUIText.text = Registry.profile.Data.gold_amount + "";
        tinUIText.text = Registry.profile.Data.tin_amount + "";
        titanUIText.text = Registry.profile.Data.titan_amount + "";
        nickelUIText.text = Registry.profile.Data.nickel_amount + "";
        tungstenUIText.text = Registry.profile.Data.tungsten_amount + "";
        copperUIText.text = Registry.profile.Data.copper_amount + "";
        ironUIText.text = Registry.profile.Data.iron_amount + "";
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
    }
}
