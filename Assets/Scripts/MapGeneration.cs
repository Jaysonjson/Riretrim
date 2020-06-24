using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapGeneration : MonoBehaviour
{
    public string text = "Doing Something!";
    public string starText = "";
    public string galaxyText = "";
    public string planetText = "";
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI starTextMesh;
    public TextMeshProUGUI galaxyTextMesh;
    public TextMeshProUGUI planetTextMesh;
    public Image image;
    public Image galaxyBar;
    public Image starBar;
    public Image planetBar;
    public float currentTask = 0;
    public float maxTasks = 0;
    public float galaxyProgress = 0;
    public float maxGalaxyProgress = 0;
    public float planetProgress = 0;
    public float maxPlanetProgress = 0;
    public float starProgress = 0;
    public float maxStarProgress = 0;
    public Thread thread;
    public bool done;

    public List<string> shipWreckNames = new List<string>();

    private void Start()
    {
        for (int i = 0; i < Registry.INSTANCE.shipWreckTypes.types.Length; i++)
        {
            shipWreckNames.Add(Registry.INSTANCE.shipWreckTypes.types[i].name);
        }
        text = "Letting Thread Sleep...";
        thread = new Thread(new ThreadStart(Generation));
        thread.IsBackground = true;
        thread.Start();
    }
    
    //Generation of the Objects
    private void Generation()
    {
        int galaxyAmount = new System.Random().Next(3, 15);
        maxTasks = galaxyAmount;
        maxGalaxyProgress = galaxyAmount;
        for (int i = 0; i < galaxyAmount; i++)
        {
            Galaxy galaxy = new Galaxy();
            currentTask++;
            galaxyProgress++;
            galaxy.Generate(this);
        }
        End();
    }

    //End of Generation, saves Profile
    private void End()
    {
        text = "Finishing...";
        currentTask = (maxTasks - 10);
        text = "Saving...";
        Registry.profile.Data.current_galaxy = Registry.adventureMap.galaxies.ElementAt(0).Value.Data.name;
        Star startStar = Registry.adventureMap.galaxies.ElementAt(0).Value.Data.stars.ElementAt(0).Value;
        startStar.Data.visited = true;
        Registry.profile.Data.current_solarsystem = startStar.Data.name;
        Registry.profile.Save();
        Registry.adventureMap.Save();
        currentTask = maxTasks;
        text = "Loading SpaceMap...";
        done = true;
        thread.Abort();
    }

    //Updating the TextMeshes with the new Text; Waiting for the background Thread to set the booleans to true
    private void Update()
    {
        textMesh.text = text;
        starTextMesh.text = starText;
        galaxyTextMesh.text = "Generating Galaxy " + galaxyProgress + " out of " + maxGalaxyProgress;
        planetTextMesh.text = planetText;
        image.fillAmount = currentTask / maxTasks;
        galaxyBar.fillAmount = galaxyProgress / maxGalaxyProgress;
        starBar.fillAmount = starProgress / maxStarProgress;
        planetBar.fillAmount = planetProgress / maxPlanetProgress;
        if (done)
        {
            StartCoroutine(switchScene());
            done = false;
        }
    }

    //Async loading of the SpaceMap, once the Generation is done
    IEnumerator switchScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("SpaceMap");
        yield return async;
    }
}
