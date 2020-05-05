using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
   public static bool isPaused = false;
   public GameObject escapeMenuObject;
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         if (!isPaused)
         {
            Pause();
         }
         else
         {
            Resume();
         }
      }
   }

   public void Pause()
   {
      escapeMenuObject.SetActive(true);
      Time.timeScale = 0f;
      isPaused = true;
   }
   
   public void Resume()
   {
      escapeMenuObject.SetActive(false);
      Time.timeScale = 1f;
      isPaused = false;
   }

   public void Save()
   {
      Profile.Save();
   }

   public void TitleScreen()
   {
      Save();
      Time.timeScale = 1f;
      SceneManager.LoadScene("Titlescreen");
   }
   
   public void Quit()
   {
      Save();      
      Application.Quit();
   }
   
   public void Shop()
   {
      Time.timeScale = 1f;
      SceneManager.LoadScene("Shop");
   }
}
