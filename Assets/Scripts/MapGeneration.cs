using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapGeneration : MonoBehaviour
{
    public TextMeshProUGUI text;
    public UnityEngine.UI.Image image;

    public int currentTask = 0;
    public int maxTasks = 500;
    void Start()
    {
        text.text = "Generating Galaxies...";
        int galaxyAmount = new System.Random().Next(15);
        maxTasks = galaxyAmount;
        for (int i = 0; i < galaxyAmount; i++)
        {
            Galaxy galaxy = new Galaxy();
            currentTask++;
            galaxy.Generate(this);
        }
        text.text = "Saving...";
        Registry.profile.Save();
    }

    private void Update()
    {
        image.fillAmount = (float)((float)currentTask / (float)maxTasks);
    }
}
