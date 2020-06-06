using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MapGeneration : MonoBehaviour
{
    public string text = "Doing Something!";
    public TextMeshProUGUI textMesh;

    public UnityEngine.UI.Image image;

    public int currentTask = 0;
    public int maxTasks = 500;
    public Thread thread;
    public bool done;
    public bool generateRest;

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
    private void Generation()
    {
        //yield return new WaitForSeconds(1f);
        int galaxyAmount = new System.Random().Next(1, 15);
        maxTasks = galaxyAmount;
        for (int i = 0; i < galaxyAmount; i++)
        {
            Galaxy galaxy = new Galaxy();
            currentTask++;
            galaxy.Generate(this);
        }
        End();
    }

    private void End()
    {
        text = "Finishing...";
        currentTask = (maxTasks - 10);
        text = "Generating Rest inside Main Thread...";
        //generateRest = true;
        text = "Saving...";
        Registry.profile.Data.current_galaxy = Registry.profile.Data.galaxies.ElementAt(0).Value.Data.name;
        Registry.profile.Data.current_solarsystem = Registry.profile.Data.galaxies.ElementAt(0).Value.Data.stars.ElementAt(0).Value.Data.name;
        Registry.profile.Save();
        currentTask = maxTasks;
        text = "Loading SpaceMap...";
        done = true;
        thread.Abort();
    }

    private void GenerateRest()
    {
        text = "Generating Rest inside Main Thread...";

        for (int i = 0; i < Registry.profile.Data.galaxies.Count; i++)
        {
            Galaxy galaxy = Registry.profile.Data.galaxies.ElementAt(i).Value;
            for (int j = 0; j < galaxy.Data.stars.Count; j++)
            {
                Star star = galaxy.Data.stars.ElementAt(j).Value;
                for (int k = 0; k < star.Data.shipWrecks.Count; k++)
                {
                    ShipWreck shipWreck = star.Data.shipWrecks.ElementAt(k).Value;
                    shipWreck.Data.type = Registry.INSTANCE.shipWreckTypes.types[new System.Random().Next(Registry.INSTANCE.shipWreckTypes.types.Length)].name;
                    Thread.Sleep(2);
                    Debug.Log("Changed ShipWreck Type at Rest... " + shipWreck.Data.type);
                }
            }
        }
        generateRest = false;
        done = true;
    }

    private void Update()
    {
        textMesh.text = text + " / Task: " + currentTask + " | Out of: " + maxTasks;
        image.fillAmount = (float)((float)currentTask / (float)maxTasks);
        if (done)
        {
            StartCoroutine(switchScene());
            done = false;
        }

        if (generateRest)
        {
            GenerateRest();
            generateRest = false;
        }
    }

    IEnumerator switchScene()
    {

        AsyncOperation async = SceneManager.LoadSceneAsync("SpaceMap");

        yield return async;

    }

    //IEnumerator StartGenerating()
    //  {
    //     
    // }
}
