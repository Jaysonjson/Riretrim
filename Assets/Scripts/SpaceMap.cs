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
        Profile.load();
        galaxyText.GetComponent<TextMeshProUGUI>().text = Profile.current_galaxy;
        solarSystemText.GetComponent<TextMeshProUGUI>().text = Profile.current_solarsystem;

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
        star.LoadUsingName(Profile.current_solarsystem);
        asteroidSpawner.amount = star.asteroid_count;
        planetSpawner.amount = star.planet_count;
        currencyAmount.text = Profile.currency + "";
        currencyName.text = Profile.currency_name;
        asteroidCountText.text = star.asteroid_count + "";
        planetCountText.text = star.planet_count + "";
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.8f);
        Planets.LoadPlanets();
        moonCountText.text = moonAmount + "";
        //yield return new WaitForSeconds(0.2f);
        //Moons.LoadMoons();
    }
    void OnApplicationQuit()
    {
        Profile.save();
        for (int i = 0; i < References.planets.Count; i++)
        {
            Planets.GetPlanet(i).position_x = Planets.GetPlanet(i).planetBody.transform.position.x;
            Planets.GetPlanet(i).position_y = Planets.GetPlanet(i).planetBody.transform.position.y;
            Planets.GetPlanet(i).save(i);
        }
    }
    public static void updateMaterialText()
    {
        aluminiumUIText.text = Profile.aluminium_amount + "";
        bronzeUIText.text = Profile.bronze_amount + "";
        carbonUIText.text = Profile.carbon_amount + "";
        coalUIText.text = Profile.coal_amount + "";
        crystalUIText.text = Profile.crystal_amount + "";
        goldUIText.text = Profile.gold_amount + "";
        tinUIText.text = Profile.tin_amount + "";
        titanUIText.text = Profile.titan_amount + "";
        nickelUIText.text = Profile.nickel_amount + "";
        tungstenUIText.text = Profile.tungsten_amount + "";
        copperUIText.text = Profile.copper_amount + "";
        ironUIText.text = Profile.iron_amount + "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Galaxyscreen");
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
