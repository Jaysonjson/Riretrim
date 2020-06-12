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

    public MapSizes size = MapSizes.MEDIUM;
    public Button MediumSizeButton;

    public void UpdateASASlider()
    {
        MapOptions.Data.AsteroidMaxSpawnAmount = (int)ASASlider.value;
        ASASliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.Data.AsteroidMaxSpawnAmount + "";
        UpdateAsteroidSliders();
    }

    public void UpdateASAMINSlider()
    {
        MapOptions.Data.AsteroidMinSpawnAmount = (int)ASAMINSlider.value;
        ASAMINSliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.Data.AsteroidMinSpawnAmount + "";
        UpdateAsteroidSliders();
    }

    public void UpdatePlanetMaxSlider()
    {
        MapOptions.Data.PlanetMaxAmount = (int)PlanetMaxSlider.value;
        PlanetMaxSliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.Data.PlanetMaxAmount + "";
    }

    public void UpdateShipWreckToggle()
    {
        MapOptions.Data.ShipWrecks = ShipwreckToggle.isOn;
    }

    public void UpdateMoonToggle()
    {
        MapOptions.Data.Moons = MoonToggle.isOn;
    }

    void Start()
    {
        ASASliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.Data.AsteroidMaxSpawnAmount + "";
        ASASlider.value = MapOptions.Data.AsteroidMaxSpawnAmount;

        ASAMINSliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.Data.AsteroidMinSpawnAmount + "";
        ASAMINSlider.value = MapOptions.Data.AsteroidMinSpawnAmount;

        PlanetMaxSliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.Data.PlanetMaxAmount + "";
        PlanetMaxSlider.value = MapOptions.Data.PlanetMaxAmount;

        ShipwreckToggle.isOn = MapOptions.Data.ShipWrecks;
        MoonToggle.isOn = MapOptions.Data.Moons;

        MediumSizeButton.Select();
    }

    public void UpdateAsteroidSliders()
    {
        ASASlider.minValue = ASAMINSlider.value + 1;
        if (ASASlider.value < ASAMINSlider.value)
        {
            ASASlider.value = ASAMINSlider.value + 1;
            MapOptions.Data.AsteroidMaxSpawnAmount = (int)ASASlider.value;
            UpdateASASlider();
        }
    }

    public void StartButton()
    {
        //Profile.start();
        MapOptions.Save();
        SceneManager.LoadScene("MapGeneration");
    }

    public void SizeSmallButton()
    {
        size = MapSizes.SMALL;
    }

    public void SizeMediumButton()
    {
        size = MapSizes.MEDIUM;
    }

    public void SizeBigButton()
    {
        size = MapSizes.BIG;
    }
}
