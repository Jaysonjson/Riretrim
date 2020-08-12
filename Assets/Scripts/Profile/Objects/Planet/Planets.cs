using System.Linq;
using UnityEngine.Experimental.Rendering.Universal;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Planets : MonoBehaviour
{

    public Planet planet;
    public GameObject[] text;
    public GameObject planetMain;
    public GameObject[] lights;
    public GameObject[] athmospheres;
    public GameObject sun;
    public GameObject moonDummy;
    public GameObject drillDummy;
    public GameObject spaceStationDummy;
    public TextMeshPro informationText;
    public GameObject miniMapIcon;

    private void Start()
    {
        SpriteRenderer planetBodySprite = GetComponent<SpriteRenderer>();
        SpriteRenderer planetMiniMapSprite = miniMapIcon.GetComponent<SpriteRenderer>();
        for (int i = 0; i < text.Length; i++)
        {
            text[i].GetComponent<TextMeshPro>().text = planet.Data.name + "\n" + planet.Data.type.ToString();
            text[0].GetComponent<TextMeshPro>().fontSize /= 4;
        }
        Sprite bodySprite = null;
        Sprite mmSprite = null;
        switch (planet.Data.type)
        {
            case PlanetType.EXOTIC:
                bodySprite = Registry.INSTANCE.planetSprites.exoticSprites[planet.Data.spriteNumber];
                mmSprite = Registry.INSTANCE.planetSprites.exoticSprites[planet.Data.spriteNumber];
                break;

            case PlanetType.LAVA:
                bodySprite = Registry.INSTANCE.planetSprites.lavaSprites[planet.Data.spriteNumber];
                mmSprite = Registry.INSTANCE.planetSprites.lavaSprites[planet.Data.spriteNumber];
                break;

            case PlanetType.ROCKY:
                bodySprite = Registry.INSTANCE.planetSprites.rockySprites[planet.Data.spriteNumber];
                mmSprite = Registry.INSTANCE.planetSprites.rockySprites[planet.Data.spriteNumber];
                break;

            case PlanetType.GAS:
                bodySprite = Registry.INSTANCE.planetSprites.gasSprites[planet.Data.spriteNumber];
                mmSprite = Registry.INSTANCE.planetSprites.gasSprites[planet.Data.spriteNumber];
                break;

            case PlanetType.ICE:
                bodySprite = Registry.INSTANCE.planetSprites.iceSprites[planet.Data.spriteNumber];
                mmSprite = Registry.INSTANCE.planetSprites.iceSprites[planet.Data.spriteNumber];
                break;

            default:
                bodySprite = Registry.INSTANCE.planetSprites.earthLikeSprites[planet.Data.spriteNumber];
                mmSprite = Registry.INSTANCE.planetSprites.earthLikeSprites[planet.Data.spriteNumber];
                break;
        }
        planetBodySprite.sprite = bodySprite;
        planetMiniMapSprite.sprite = mmSprite;
        planetMain.name = planet.Data.name;
        name = planet.Data.name + "-Body";
        planetMain.transform.position = new Vector3(planet.Data.position.x, planet.Data.position.y, -780f);
        planetMain.transform.localScale = new Vector3(planet.Data.scale, planet.Data.scale, 1);
        informationText.text = "Materials: ";
        for (var i = 0; i < planet.Data.materials.Count; i++)
        {
            informationText.text += planet.Data.materials[i].ToString() + ", ";
        }

        informationText.text += "\nDrills: PLACEHOLDER";
        for (var i = 0; i < lights.Length; i++)
        {
            lights[i].GetComponent<Light2D>().color = new Color32(planet.Data.color[0], planet.Data.color[1], planet.Data.color[2], 255);
            lights[i].GetComponent<Light2D>().pointLightOuterRadius += (float)((planet.Data.scale / 2.5));
        }

        for (var i = 0; i < athmospheres.Length; i++)
        {
            athmospheres[i].GetComponent<SpriteRenderer>().color = new Color32(planet.Data.color[0], planet.Data.color[1], planet.Data.color[2], 255);
        }

        for (int i = 0; i < planet.Data.moons.Count; i++)
        {
            Moon moon = planet.Data.moons.ElementAt(i).Value;
            GameObject moonObject = Instantiate(moonDummy, gameObject.transform, false);
            moonObject.GetComponent<Moons>().moon = moon;
        }

        for (int i = 0; i < planet.Data.spaceStations.Count; i++)
        {
            SpaceStation spaceStation = planet.Data.spaceStations.ElementAt(i).Value;
            GameObject spaceStationObject = Instantiate(spaceStationDummy, gameObject.transform, false);
            spaceStationObject.GetComponent<SpaceStations>().spaceStation = spaceStation;
        }
        if (!planet.Data.orbit.speededOrbit)
        {
            GetComponent<Orbit>().speed = planet.Data.orbit.speed;
        }
        else
        {
            GetComponent<Orbit>().speed = new System.Random().Next(200, 500);
            StartCoroutine(stopSpeededOrbit(planet));
        }

    }

    IEnumerator stopSpeededOrbit(Planet planet)
    {
        yield return new WaitForSeconds(0.5f);
        planet.Data.orbit.speededOrbit = false;
        GetComponent<Orbit>().speed = planet.Data.orbit.speed;
    }


    /*
        public static IEnumerator updateSpeed(int i)
        {
            yield return new WaitForSeconds(0.3f);
            GetPlanet(i).planetMain.GetComponent<Orbit>().speed = GetPlanet(i).Data.speed;
        }
    */
    public void Click()
    {
        Registry.profile.Data.current_planet = gameObject.name.Replace("-Body", "");
        SceneManager.LoadScene("PlanetMap");
    }
}

