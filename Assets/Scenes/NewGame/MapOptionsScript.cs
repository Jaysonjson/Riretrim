using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapOptionsScript : MonoBehaviour
{
    public GameObject ASASliderValue;
    public Slider ASASlider;

    public GameObject ASAMINSliderValue;
    public Slider ASAMINSlider;

    public GameObject PlanetMaxSliderValue;
    public Slider PlanetMaxSlider;

    public Toggle ShipwreckToggle;

    public Toggle MoonToggle;
    
    public void UpdateASASlider()
    {
        MapOptions.AsteroidMaxSpawnAmount = (int) ASASlider.value;
        ASASliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.AsteroidMaxSpawnAmount + "";
        UpdateAsteroidSliders();
    }
    
    public void UpdateASAMINSlider()
    {
        MapOptions.AsteroidMinSpawnAmount = (int) ASAMINSlider.value;
        ASAMINSliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.AsteroidMinSpawnAmount + "";
        UpdateAsteroidSliders();
    }

    public void UpdatePlanetMaxSlider()
    {
        MapOptions.PlanetMaxAmount = (int) PlanetMaxSlider.value;
        PlanetMaxSliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.PlanetMaxAmount + "";
    }
    
    public void UpdateShipWreckToggle()
    {
        MapOptions.ShipWrecks = ShipwreckToggle.isOn;
    }

    public void UpdateMoonToggle()
    {
        MapOptions.Moons = MoonToggle.isOn;
    }
    
    void Start()
    {
        ASASliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.AsteroidMaxSpawnAmount + "";
        ASASlider.value = MapOptions.AsteroidMaxSpawnAmount;
        
        ASAMINSliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.AsteroidMinSpawnAmount + "";
        ASAMINSlider.value = MapOptions.AsteroidMinSpawnAmount;

        PlanetMaxSliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.PlanetMaxAmount + "";
        PlanetMaxSlider.value = MapOptions.PlanetMaxAmount;

        ShipwreckToggle.isOn = MapOptions.ShipWrecks;
        MoonToggle.isOn = MapOptions.Moons;
    }

    public void UpdateAsteroidSliders()
    {
        ASASlider.minValue = ASAMINSlider.value + 1;
        if (ASASlider.value < ASAMINSlider.value)
        {
            ASASlider.value = ASAMINSlider.value + 1;
            MapOptions.AsteroidMaxSpawnAmount = (int) ASASlider.value;
            UpdateASASlider();
        }
    }

    public void StartButton()
    {
        //Profile.start();
        MapOptions.save();
        SceneManager.LoadScene("Galaxyscreen");
    }
}
