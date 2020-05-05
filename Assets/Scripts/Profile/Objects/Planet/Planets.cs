using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planets : MonoBehaviour
{
    public static string current_planet = "none";
    public GameObject[] text;
    public GameObject planetMain;
    public GameObject[] lights;
    public GameObject[] atmospheres;
    public GameObject sun;
    public GameObject moonDummy;
    public GameObject drillDummy;
    public GameObject spaceStationDummy;
    public TextMeshPro informationText;
    public Sprite[] EarthLikeSprites;
    public Sprite[] LavaSprites;
    public Sprite[] GasSprites;
    public Sprite[] RockySprites;
    public Sprite[] ExoticSprites;
    public Sprite[] IceSprites;
    public static Planets instance;
    public GameObject miniMapIcon;
    public static Sprite[] earthLikeSprites;
    public static Sprite[] lavaSprites;
    public static Sprite[] gasSprites;
    public static Sprite[] rockySprites;
    public static Sprite[] exoticSprites;
    public static Sprite[] iceSprites;

    public Planet addPlanet(Planet planet)
    {
        planet.index = References.planets.Count;
        References.planets.Add(planet);
        return planet;
    }

    public static Planet GetPlanet(int index)
    {
        return References.planets[index];
    }

    void Start()
    {
        earthLikeSprites = EarthLikeSprites;
        lavaSprites = LavaSprites;
        gasSprites = GasSprites;
        rockySprites = RockySprites;
        exoticSprites = ExoticSprites;
        iceSprites = IceSprites;
        addPlanet(new Planet(text, gameObject, planetMain, lights, atmospheres, sun, miniMapIcon, moonDummy, drillDummy, spaceStationDummy, informationText));
    }

    void Awake()
    {
        instance = this;
    }

    public static void LoadPlanets()
    {
        for (int i = 0; i < References.planets.Count; i++)
        {
            GetPlanet(i).Generate();
            GetPlanet(i).save(i);
            SpaceMap.moonAmount += GetPlanet(i).moonAmount;
            instance.StartCoroutine(updateSpeed(i));
        }
    }

    public static IEnumerator updateSpeed(int i)
    {
        yield return new WaitForSeconds(0.3f);
        GetPlanet(i).planetMain.GetComponent<Orbit>().speed = GetPlanet(i).speed;
    }

    public void Click()
    {
        Registry.profile.Data.current_planet = gameObject.name.Replace("-Body", "");
        SceneManager.LoadScene("PlanetMap");
    }
}

