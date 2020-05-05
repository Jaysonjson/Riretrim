using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Registry : MonoBehaviour
{
    public static Language Language = new Language();
    public TextAsset defaultLangFile;
    public static Profile profile = new Profile();
    private void Start()
    {
        References.sprite = gameObject.GetComponent<Sprites>();
        Debug.Log("Loading Languages..");
        Options.load();
        if (Options.Language != "English")
        {
            defaultLangFile = Resources.Load(Options.Language) as TextAsset;
        }

        if (defaultLangFile != null)
        {
            JsonUtility.FromJsonOverwrite(defaultLangFile.text, Language);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // StartCoroutine(End());
    }
    
    IEnumerator End()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}