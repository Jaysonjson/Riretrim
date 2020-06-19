using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GalaxyMap : MonoBehaviour
{

    public GameObject galaxyText;
    
    void Start()
    {
        galaxyText.GetComponent<TextMeshProUGUI>().text = Registry.profile.Data.current_galaxy;
        //Registry.profile.Data.galaxies.Add("test", new Galaxy());
        //Debug.Log(Registry.profile.Data.galaxies["test"].Data.name);
        Registry.profile.Save();
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Loading Stars..");
        //Stars.LoadStars();
    }
    void OnApplicationQuit()
    {
        Registry.profile.Save();
       // for (int i = 0; i < References.planets.Count; i++)
       // {
           //Stars.GetPlanet(i).position_x = Planets.GetPlanet(i).planet.transform.position.x;
            //Planets.GetPlanet(i).position_y = Planets.GetPlanet(i).planet.transform.position.y;
           // Planets.GetPlanet(i).save(i);
      //  }
    }
}
