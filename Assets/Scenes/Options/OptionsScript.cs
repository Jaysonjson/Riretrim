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
        Options.Load();
        asteroidDespawnDistanceSliderValue.GetComponent<TextMeshProUGUI>().text = Options.Data.AsteroidDespawnDistance + "";
        asteroidDespawnDistanceSlider.value = Options.Data.AsteroidDespawnDistance;
        asteroidShadowToggle.isOn = Options.Data.AsteroidShadows;
        particleSystemToggle.isOn = Options.Data.ParticleSystems;
        objectShadowToggle.isOn = Options.Data.ObjectShadows;
        lightToggle.isOn = Options.Data.Lights;
        showFPSToggle.isOn = Options.Data.ShowFPS;
        for (var i = 0; i < languageDropdown.options.Count; i++)
        {
            if (languageDropdown.options[i].text.Equals(Options.Data.Language))
            {
                languageDropdown.value = i;
                break;
            }
        }
    }

    public void UpdateAsteroidDespawnDistanceSliderValue()
    {
        Options.Data.AsteroidDespawnDistance = asteroidDespawnDistanceSlider.value;
        asteroidDespawnDistanceSliderValue.GetComponent<TextMeshProUGUI>().text = Options.Data.AsteroidDespawnDistance + "";
    }
    
    public void UpdateAsteroidsShadowToggle()
    {
        Options.Data.AsteroidShadows = asteroidShadowToggle.isOn;
    }

    public void UpdateParticleSystemToggle()
    {
        Options.Data.ParticleSystems = particleSystemToggle.isOn;
    }
    public void UpdateObjectShadowToggle()
    {
        Options.Data.ObjectShadows = objectShadowToggle.isOn;
    }

    public void UpdateShowFPSToggle()
    {
        Options.Data.ShowFPS = showFPSToggle.isOn;
    }

    public void UpdateLanguageDropdown()
    {
        Options.Data.Language = languageDropdown.options[languageDropdown.value].text;
    }
    
    public void UpdateLightsToggle()
    {
        Options.Data.Lights = lightToggle.isOn;
    }
    public void saveButton()
    {
        Options.Save();
        SceneManager.LoadScene("Titlescreen");
    }

    public void returnToTitlescreen()
    {
        SceneManager.LoadScene("Titlescreen");
    }
}
