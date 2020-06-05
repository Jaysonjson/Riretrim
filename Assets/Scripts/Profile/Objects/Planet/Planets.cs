using UnityEngine.Experimental.Rendering.Universal;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Start()
    {
        SpriteRenderer planetBodySprite = GetComponent<SpriteRenderer>();
        SpriteRenderer planetMiniMapSprite = miniMapIcon.GetComponent<SpriteRenderer>();
        GetComponent<Orbit>().speed = new System.Random().Next(120, 500);
        for (int i = 0; i < text.Length; i++)
        {
            text[i].GetComponent<TextMeshPro>().text = planet.Data.name + "\n" + planet.Data.type.ToString();
            text[0].GetComponent<TextMeshPro>().fontSize /= 4;
        }
        if (planet.Data.type == PlanetType.EXOTIC)
        {
            planetBodySprite.sprite = Planets.exoticSprites[planet.Data.spriteNumber];
            planetMiniMapSprite.sprite = Planets.exoticSprites[planet.Data.spriteNumber];
        }
        if (planet.Data.type == PlanetType.EARTHLIKE)
        {
            planetBodySprite.sprite = Planets.earthLikeSprites[planet.Data.spriteNumber];
            planetMiniMapSprite.sprite = Planets.earthLikeSprites[planet.Data.spriteNumber];
        }
        if (planet.Data.type == PlanetType.LAVA)
        {
            planetBodySprite.sprite = Planets.lavaSprites[planet.Data.spriteNumber];
            planetMiniMapSprite.sprite = Planets.lavaSprites[planet.Data.spriteNumber];
        }
        if (planet.Data.type == PlanetType.ROCKY)
        {
            planetBodySprite.sprite = Planets.rockySprites[planet.Data.spriteNumber];
            planetMiniMapSprite.sprite = Planets.rockySprites[planet.Data.spriteNumber];
        }
        if (planet.Data.type == PlanetType.GAS)
        {
            planetBodySprite.sprite = Planets.gasSprites[planet.Data.spriteNumber];
            planetMiniMapSprite.sprite = Planets.gasSprites[planet.Data.spriteNumber];
        }
        if (planet.Data.type == PlanetType.ICE)
        {
            planetBodySprite.sprite = Planets.iceSprites[planet.Data.spriteNumber];
            planetMiniMapSprite.sprite = Planets.iceSprites[planet.Data.spriteNumber];
        }
        planetMain.name = planet.Data.name;
        name = planet.Data.name + "-Body";
        planetMain.transform.position = new Vector3(planet.Data.position_x, planet.Data.position_y, -780f);
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
        GetComponent<Orbit>().speed = planet.Data.speed;
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

