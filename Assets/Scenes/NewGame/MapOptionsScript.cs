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
    
    public void UpdateASASlider()
    {
        MapOptions.asteroid_max_spawn_amount = (int) ASASlider.value;
        ASASliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.asteroid_max_spawn_amount + "";
        UpdateAsteroidSliders();
    }
    
    public void UpdateASAMINSlider()
    {
        MapOptions.asteroid_min_spawn_amount = (int) ASAMINSlider.value;
        ASAMINSliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.asteroid_min_spawn_amount + "";
        UpdateAsteroidSliders();
    } 
    
    void Start()
    {
        ASASliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.asteroid_max_spawn_amount + "";
        ASASlider.value = MapOptions.asteroid_max_spawn_amount;
        
        ASAMINSliderValue.GetComponent<TextMeshProUGUI>().text = MapOptions.asteroid_min_spawn_amount + "";
        ASAMINSlider.value = MapOptions.asteroid_min_spawn_amount;
    }

    public void UpdateAsteroidSliders()
    {
        ASASlider.minValue = ASAMINSlider.value + 1;
        if (ASASlider.value < ASAMINSlider.value)
        {
            ASASlider.value = ASAMINSlider.value + 1;
            MapOptions.asteroid_max_spawn_amount = (int)ASASlider.value;
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
