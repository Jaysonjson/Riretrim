using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsScript : MonoBehaviour
{
    public Slider asteroidDespawnDistanceSlider;
    public GameObject asteroidDespawnDistanceSliderValue;
    public Toggle asteroidShadowToggle;
    public Toggle particleSystemToggle;
    public Toggle objectShadowToggle;
    public Toggle lightToggle;
    void Start()
    {
        Options.load();
        asteroidDespawnDistanceSliderValue.GetComponent<TextMeshProUGUI>().text = Options.AsteroidDespawnDistance + "";
        asteroidDespawnDistanceSlider.value = Options.AsteroidDespawnDistance;
        asteroidShadowToggle.isOn = Options.AsteroidShadows;
        particleSystemToggle.isOn = Options.ParticleSystems;
        objectShadowToggle.isOn = Options.ObjectShadows;
        lightToggle.isOn = Options.Lights;
    }

    public void UpdateAsteroidDespawnDistanceSliderValue()
    {
        Options.AsteroidDespawnDistance = asteroidDespawnDistanceSlider.value;
        asteroidDespawnDistanceSliderValue.GetComponent<TextMeshProUGUI>().text = Options.AsteroidDespawnDistance + "";
    }
    
    public void UpdateAsteroidsShadowToggle()
    {
        Options.AsteroidShadows = asteroidShadowToggle.isOn;
    }

    public void UpdateParticleSystemToggle()
    {
        Options.ParticleSystems = particleSystemToggle.isOn;
    }
    public void UpdateObjectShadowToggle()
    {
        Options.ObjectShadows = objectShadowToggle.isOn;
    }

    public void UpdateLightsToggle()
    {
        Options.Lights = lightToggle.isOn;
    }
    public void saveButton()
    {
        Options.save();
        SceneManager.LoadScene("Titlescreen");
    }

    public void returnToTitlescreen()
    {
        SceneManager.LoadScene("Titlescreen");
    }
}
