using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsScript : MonoBehaviour
{
    public Slider ADDSlider;
    public GameObject ADDSliderValue;
    public Toggle asteroidShadowToggle;
    public Toggle particleSystemToggle;
    public Toggle objectShadowToggle;
    void Start()
    {
        Options.load();
        ADDSliderValue.GetComponent<TextMeshProUGUI>().text = Options.AsteroidDespawnDistance + "";
        ADDSlider.value = Options.AsteroidDespawnDistance;
        asteroidShadowToggle.isOn = Options.AsteroidShadows;
        particleSystemToggle.isOn = Options.ParticleSystems;
        objectShadowToggle.isOn = Options.ObjectShadows;
    }

    public void UpdateADDSlider()
    {
        Options.AsteroidDespawnDistance = ADDSlider.value;
        ADDSliderValue.GetComponent<TextMeshProUGUI>().text = Options.AsteroidDespawnDistance + "";
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
