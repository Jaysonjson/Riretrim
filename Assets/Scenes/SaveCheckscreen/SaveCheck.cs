using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveCheck : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    void Start()
    {
        infoText.text = "Your current save is from " + Registry.profile.Data.save_version + ". Current game is on " + Application.version + "!";
    }
    public void ContinueButton()
    {
        SceneManager.LoadScene("SpaceMap");
    }
}
