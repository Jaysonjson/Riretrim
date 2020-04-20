using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlescreenButton : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Gamescreen");
    }
    public void MapButton()
    {
        Profile.load();
        Profile.start();
        //SceneManager.LoadScene("SpaceMap");
        if (!Profile.gameStart)
        {
           // SceneManager.LoadScene("Galaxyscreen");
        }
    }
    public void ASButton()
    {
        SceneManager.LoadScene("AdditionalSoftware");
    }
    public void KBButton()
    {
        SceneManager.LoadScene("Keybindsscreen");
    }
    public void DiscordButton()
    {
        Application.OpenURL("https://discord.gg/jhK6Ab3");
    }
    public void OptionsButton()
    {
        SceneManager.LoadScene("Options");
    }
    public void CreditsButton()
    {
        SceneManager.LoadScene("Creditsscreen");
    }
}
