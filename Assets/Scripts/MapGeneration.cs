using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
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


    private void Start()
    {
       // StartCoroutine(StartGenerating());
        text = "Letting Thread Sleep...";
        thread = new Thread(new ThreadStart(Generation));
        thread.IsBackground = true;
        thread.Start();
    }
    private void Generation() {
        //yield return new WaitForSeconds(1f);
        int galaxyAmount = new System.Random().Next(15);
        maxTasks = galaxyAmount;
        for (int i = 0; i < galaxyAmount; i++)
        {
            Galaxy galaxy = new Galaxy();
            currentTask++;
            galaxy.Generate(this);
        }
        End();
    }

    private void End() {
        text = "Finishing...";
        text = "Saving...";
        Registry.profile.Save();
        thread.Abort();
    }

    private void Update()
    {
        textMesh.text = text + " / Task: " + currentTask + " | Out of: " + maxTasks;
        image.fillAmount = (float)((float)currentTask / (float)maxTasks);
    }

    //IEnumerator StartGenerating()
  //  {
   //     
   // }
}
