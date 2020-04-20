using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Registry : MonoBehaviour
{
    private void Start()
    {
        References.sprite = gameObject.GetComponent<Sprites>();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // StartCoroutine(End());
    }
    
    IEnumerator End()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}