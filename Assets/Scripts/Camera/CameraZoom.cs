using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CameraZoom : MonoBehaviour
{
    public float zoomSize;
    public float standartSize = 2.5f;
    public GameObject zoomText;
    public static List<GameObject> asteroids = new List<GameObject>();
    void Update()
    {
        Camera cameraComp = GetComponent<Camera>();
        //GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        if (Input.GetKey(KeyCode.Z) && cameraComp.orthographicSize < 150)
        {
            cameraComp.orthographicSize = cameraComp.orthographicSize + zoomSize;
            if(zoomText != null)
            {
                zoomText.SetActive(true);
                zoomText.GetComponent<TextMeshProUGUI>().text = cameraComp.orthographicSize + "x";
                //UpdateOtherText(cameraComp);
            }
            if (cameraComp.orthographicSize > Options.AsteroidDespawnDistance)
            {
                for (int i = 0; i < asteroids.Count; i++)
                {
                    asteroids[i].SetActive(false);
                    /* MonoBehaviour[] components = asteroids[i].GetComponents<MonoBehaviour>();
                    asteroids[i].GetComponent<SpriteRenderer>().enabled = false;
                    foreach (MonoBehaviour c in components)
                    {
                        c.enabled = false;
                    }
                    */
                }
            }
        }
        if (Input.GetKey(KeyCode.U) && cameraComp.orthographicSize > 0.5)
        {
            cameraComp.orthographicSize = cameraComp.orthographicSize - zoomSize;
            if (zoomText != null)
            {
                zoomText.SetActive(true);
                zoomText.GetComponent<TextMeshProUGUI>().text = cameraComp.orthographicSize + "x";
                //UpdateOtherText(cameraComp);
            }
            if (cameraComp.orthographicSize < Options.AsteroidDespawnDistance)
            {
                for (int i = 0; i < asteroids.Count; i++)
                {
                    asteroids[i].SetActive(true);
                   /* MonoBehaviour[] components = asteroids[i].GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour c in components)
                    {
                        c.enabled = true;
                    }
                    */
                }
            }
        }
        if (Input.GetKey(KeyCode.I))
        {
            cameraComp.orthographicSize = standartSize;
            if (zoomText != null)
            {
                zoomText.SetActive(true);
                zoomText.GetComponent<TextMeshProUGUI>().text = cameraComp.orthographicSize + "x";
               // UpdateOtherText(cameraComp);
            }
            for (int i = 0; i < asteroids.Count; i++)
            {
                asteroids[i].SetActive(true);
            }
        }
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.U) || Input.GetKeyUp(KeyCode.I))
        {
            StartCoroutine(waiter(cameraComp));
        }

    }

    void UpdateOtherText(Camera cameraComp)
    {
        for (int i = 0; i < References.planets.Count; i++)
        {
            for (int j = 0; j < Planets.GetPlanet(i).text.Length; j++)
            {
                Planets.GetPlanet(i).text[j].GetComponent<TextMeshPro>().fontSize = cameraComp.orthographicSize / 7;
            }
        }
    }

    IEnumerator waiter(Camera cameraComp)
    {
        yield return new WaitForSeconds(0.2f);
        UpdateOtherText(cameraComp);
        yield return new WaitForSeconds(2.25f);
        if (zoomText != null)
        {
            zoomText.SetActive(false);
        }
    }
}