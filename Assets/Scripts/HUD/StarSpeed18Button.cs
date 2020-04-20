using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StarSpeed18Button : MonoBehaviour
{
    void Start()
    {
        if(!SystemInfo.operatingSystem.Contains("Window") && Directory.Exists(Application.dataPath + "/StarSpeed18/")) 
        {
            //gameObject.SetActive(false);
            GetComponent<Button>().interactable = false;
        }
    }
    public void onClick()
    {
            Process p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = Application.dataPath + "/StarSpeed18/StarSpeed18.exe";
            p.Start();
    }
}
