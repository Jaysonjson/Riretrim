using System.Threading;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileSelection : MonoBehaviour
{
    public GameObject ProfileObject;
    public GameObject[] spawnPoints;
    public GameObject currentSpawn;
    void Start()
    {
        string[] directories = Directory.GetDirectories(Application.persistentDataPath + "/profiles/");

        for (int i = 0; i < directories.Length; i++)
        {
            Profile profile = new Profile();
            profile.Data.Load(directories[i], profile);
            GameObject profileObject = profile.Data.current ? Instantiate(ProfileObject, currentSpawn.transform) : Instantiate(ProfileObject, spawnPoints[i].transform);
            profileObject.GetComponent<ProfileObject>().profile = profile;
            profileObject.SetActive(true);
        }
    }
}
