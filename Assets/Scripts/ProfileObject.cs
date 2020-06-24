using System.IO;
using System;
using TMPro;
using UnityEngine;

public class ProfileObject : MonoBehaviour
{

    public TextMeshProUGUI versionText;
    public TextMeshProUGUI profileNameText;
    public TextMeshProUGUI sizeText;
    public Color greenColor;
    public Color redColor;
    public Profile profile;
    private void Start()
    {
        if (profile != null)
        {
            profileNameText.text = profile.Data.profileName;
            if (profile.Data.save_version != Application.version)
            {
                versionText.color = redColor;
            }
            else
            {
                versionText.color = greenColor;
            }
            versionText.text = profile.Data.save_version;
            sizeText.text = (DirSize(new DirectoryInfo(Application.persistentDataPath + "/profiles/" + profile.Data.profileName)) / 1e+6).ToString("N1") + " MB";

        }
    }

    public static long DirSize(DirectoryInfo d)
    {
        long size = 0;
        FileInfo[] fis = d.GetFiles();
        foreach (FileInfo fi in fis)
        {
            size += fi.Length;
        }
        DirectoryInfo[] dis = d.GetDirectories();
        foreach (DirectoryInfo di in dis)
        {
            size += DirSize(di);
        }
        return size;
    }
}
