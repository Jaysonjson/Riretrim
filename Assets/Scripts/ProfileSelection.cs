using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileSelection : MonoBehaviour
{
    public GameObject ProfileObject;
    void Start()
    {
        string[] directories = Directory.GetDirectories(Application.persistentDataPath + "/profiles/");
        for (int i = 0; i < directories.Length; i++)
        {
            Profile profile = new Profile();
            profile.Data.Load(directories[i]);
            GameObject profileObject = Instantiate(ProfileObject, gameObject.transform);
            profileObject.GetComponent<ProfileObject>().profile = profile;
            profileObject.SetActive(true);
        }
    }
}
