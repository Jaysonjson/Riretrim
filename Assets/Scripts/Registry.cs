using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Registry : MonoBehaviour
{
    public static Language Language = new Language();
    public static Names Names = new Names();
    public TextAsset defaultLangFile;
    public TextAsset defaultNames;
    public static Profile profile = new Profile();
    private void Start()
    {
        References.sprite = gameObject.GetComponent<Sprites>();
        Debug.Log("Loading Languages..");
        Options.Load();
        if (Options.Data.Language != "English")
        {
            defaultLangFile = Resources.Load("lang/" + Options.Data.Language) as TextAsset;
        }

        if (defaultLangFile != null)
        {
            JsonUtility.FromJsonOverwrite(defaultLangFile.text, Language);
        }

        if(defaultNames != null)
        {
           JsonUtility.FromJsonOverwrite(defaultNames.text, Names);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // StartCoroutine(End());
        Mods.ships = ModdedShipUtility.GetShips();
    }
    
    IEnumerator End()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}