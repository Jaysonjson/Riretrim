using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Registry : MonoBehaviour
{
    public static Language Language = new Language();
    public static Names Names = new Names();
    public TextAsset defaultLangFile;
    public TextAsset defaultNames;
    public static readonly Profile profile = new Profile();
    public ShipWreckTypes shipWreckTypes;
    public PlanetSprites planetSprites;
    public StarSprites starSprites;
    public Sprites sprites;
    public static Registry INSTANCE;
    public static AdventureMap adventureMap = new AdventureMap();
    void Start()
    {
        sprites = gameObject.GetComponent<Sprites>();
        Options.Load();
        profile.SetUp(Options.Data.CurrentProfile);
        LoadLanguage();
        if (defaultNames != null)
        {
            JsonUtility.FromJsonOverwrite(defaultNames.text, Names);
        }

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Mods.ships = ModdedShipUtility.GetShips();
        INSTANCE = this;
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLanguage()
    {
        if (Options.Data.Language != "English")
        {
            defaultLangFile = Resources.Load("lang/" + Options.Data.Language) as TextAsset;
        }
        else
        {
            Language = new Language();
        }
        if (defaultLangFile != null)
        {
            JsonUtility.FromJsonOverwrite(defaultLangFile.text, Language);
        }
    }

}