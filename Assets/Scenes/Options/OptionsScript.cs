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
    public Toggle ASToggle;
    public Toggle PSToggle;
    void Start()
    {
        Options.load();
        ADDSliderValue.GetComponent<TextMeshProUGUI>().text = Options.asteroid_despawn_distance + "";
        ADDSlider.value = Options.asteroid_despawn_distance;
        ASToggle.isOn = Options.asteroid_shadows;
        PSToggle.isOn = Options.particle_systems;
    }

    public void UpdateADDSlider()
    {
        Options.asteroid_despawn_distance = ADDSlider.value;
        ADDSliderValue.GetComponent<TextMeshProUGUI>().text = Options.asteroid_despawn_distance + "";
    }
    
    public void UpdateASToggle()
    {
        Options.asteroid_shadows = ASToggle.isOn;
    }

    public void UpdatePSToggle()
    {
        Options.particle_systems = PSToggle.isOn;
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
