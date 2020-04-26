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

    public Toggle ShipwreckToggle;
    
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

    public void UpdateShipWreckToggle()
    {
        MapOptions.ShipWrecks = ShipwreckToggle.isOn;
    }
    
    void Start()
    {
        ASASliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.AsteroidMaxSpawnAmount + "";
        ASASlider.value = MapOptions.AsteroidMaxSpawnAmount;
        
        ASAMINSliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.AsteroidMinSpawnAmount + "";
        ASAMINSlider.value = MapOptions.AsteroidMinSpawnAmount;

        ShipwreckToggle.isOn = MapOptions.ShipWrecks;
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
