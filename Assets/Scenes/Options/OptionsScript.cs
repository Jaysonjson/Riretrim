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
    public Toggle showFPSToggle;
    public TMP_Dropdown languageDropdown;
    void Start()
    {
        Options.load();
        asteroidDespawnDistanceSliderValue.GetComponent<TextMeshProUGUI>().text = Options.AsteroidDespawnDistance + "";
        asteroidDespawnDistanceSlider.value = Options.AsteroidDespawnDistance;
        asteroidShadowToggle.isOn = Options.AsteroidShadows;
        particleSystemToggle.isOn = Options.ParticleSystems;
        objectShadowToggle.isOn = Options.ObjectShadows;
        lightToggle.isOn = Options.Lights;
        showFPSToggle.isOn = Options.ShowFPS;
        for (var i = 0; i < languageDropdown.options.Count; i++)
        {
            if (languageDropdown.options[i].text.Equals(Options.Language))
            {
                languageDropdown.value = i;
                break;
            }
        }
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

    public void UpdateShowFPSToggle()
    {
        Options.ShowFPS = showFPSToggle.isOn;
    }

    public void UpdateLanguageDropdown()
    {
        Options.Language = languageDropdown.options[languageDropdown.value].text;
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
