using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsScript : MonoBehaviour
{
    public Slider asteroidDespawnDistanceSlider;
    public Slider hudScaleSlider;
    public GameObject asteroidDespawnDistanceSliderValue;
    public TextMeshProUGUI hudScaleValue;
    public Toggle asteroidShadowToggle;
    public Toggle particleSystemToggle;
    public Toggle objectShadowToggle;
    public Toggle lightToggle;
    public Toggle showFPSToggle;
    public Toggle autoSaveToggle;
    public Toggle postProcessingToggle;
    public TMP_Dropdown languageDropdown;
    public TMP_Dropdown minimapHUD;
    public CanvasScaler CanvasScaler;
    private int __old_res;
    void Start()
    {
        Options.Load();
        __old_res = Options.Data.HUDScale;
        asteroidDespawnDistanceSliderValue.GetComponent<TextMeshProUGUI>().text = Options.Data.AsteroidDespawnDistance + "";
        asteroidDespawnDistanceSlider.value = Options.Data.AsteroidDespawnDistance;
        asteroidShadowToggle.isOn = Options.Data.AsteroidShadows;
        particleSystemToggle.isOn = Options.Data.ParticleSystems;
        objectShadowToggle.isOn = Options.Data.ObjectShadows;
        lightToggle.isOn = Options.Data.Lights;
        showFPSToggle.isOn = Options.Data.ShowFPS;
        hudScaleSlider.value = Options.Data.HUDScale;
        postProcessingToggle.isOn = Options.Data.PostProcessing;
        hudScaleValue.text = Options.Data.HUDScale + "";
        autoSaveToggle.isOn = Options.Data.AutoSave;
        CanvasScaler.referenceResolution = new Vector2(Options.Data.HUDScale, 1080);
        for (var i = 0; i < languageDropdown.options.Count; i++)
        {
            if (languageDropdown.options[i].text.Equals(Options.Data.Language))
            {
                languageDropdown.value = i;
                break;
            }
        }

        for (var i = 0; i < minimapHUD.options.Count; i++)
        {
            if (minimapHUD.options[i].text.ToUpper().Equals(Options.Data.MiniMapHud.ToString()))
            {
                minimapHUD.value = i;
                break;
            }
        }
    }

    public void UpdateAsteroidDespawnDistanceSliderValue()
    {
        Options.Data.AsteroidDespawnDistance = asteroidDespawnDistanceSlider.value;
        asteroidDespawnDistanceSliderValue.GetComponent<TextMeshProUGUI>().text = Options.Data.AsteroidDespawnDistance + "";
    }

    public void UpdateHUDScaleSlider()
    {
        Options.Data.HUDScale = (int)hudScaleSlider.value;
        hudScaleValue.text = Options.Data.HUDScale + "";
        //CanvasScaler.referenceResolution = new Vector2(Options.Data.HUDScale, 1080);
    }

    public void HUDShow()
    {
        CanvasScaler.referenceResolution = new Vector2(Options.Data.HUDScale, 1080);
        StartCoroutine(HUDShowReset());
    }

    IEnumerator HUDShowReset()
    {
        yield return new WaitForSeconds(3f);
        CanvasScaler.referenceResolution = new Vector2(__old_res, 1080);
        Options.Data.HUDScale = __old_res;
    }

    public void UpdateAsteroidsShadowToggle()
    {
        Options.Data.AsteroidShadows = asteroidShadowToggle.isOn;
    }

    public void UpdatePostProcessingToggle()
    {
        Options.Data.PostProcessing = postProcessingToggle.isOn;
    }

    public void UpdateAutoSaveToggle()
    {
        Options.Data.AutoSave = autoSaveToggle.isOn;
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

    public void UpdateMiniMapHUDDropdown()
    {
        Options.Data.MiniMapHud = (MiniMapHUD)Enum.Parse(typeof(MiniMapHUD), minimapHUD.options[minimapHUD.value].text.ToUpper());
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
