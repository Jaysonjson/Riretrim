using System.Threading;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileSelection : MonoBehaviour
{
    public GameObject ProfileObject;
    public GameObject SlotObject;
    public GameObject[] spawnPoints;
    public GameObject currentSpawn;
    void Start()
    {
        string[] directories = Directory.GetDirectories(Application.persistentDataPath + "/profiles/");
        int spawnPoint = 0;
        for (int i = 0; i < directories.Length; i++)
        {
            Profile profile = new Profile();
            profile.Data.Load(directories[i], profile);
            GameObject profileObject = (profile.Data.profileName == Options.Data.CurrentProfile) ? Instantiate(ProfileObject, currentSpawn.transform) : Instantiate(ProfileObject, spawnPoints[spawnPoint].transform);
            if (profile.Data.profileName != Options.Data.CurrentProfile) spawnPoint++;
            profileObject.GetComponent<ProfileObject>().profile = profile;
            profileObject.SetActive(true);
        }
        for (int i = spawnPoint; i < spawnPoints.Length; i++)
        {
            GameObject slotObject = Instantiate(SlotObject, spawnPoints[i].transform);
            slotObject.SetActive(true);
        }
    }
}
