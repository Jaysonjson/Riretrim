using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Escape : MonoBehaviour
{
    void Update()
    { 
        if(Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Titlescreen");
        }
    }
}
