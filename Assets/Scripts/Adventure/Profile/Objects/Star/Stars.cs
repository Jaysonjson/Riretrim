using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class Stars : MonoBehaviour
{
    public Star star;
    public TextMeshPro text;

    public Light2D[] lights;
    private void Start()
    {
        TextMeshPro textMesh = text.GetComponent<TextMeshPro>();
        textMesh.text = star.Data.name + "\nLast Visited on: " + star.Data.visitTime.convertToDateTime().ToString("dd/M/yyyy hh:mm:ss");
        if (star.Data.visited)
        {
            textMesh.color = new Color32(0, 163, 14, 255);
        }
        else
        {
            textMesh.color = new Color32(163, 0, 0, 255);
        }
        name = star.Data.name;
        GetComponent<Orbit>().speed = star.Data.orbit.speed;
        GetComponent<SpriteRenderer>().color = new Color32(star.Data.color[0], star.Data.color[1], star.Data.color[2], 255);
        transform.position = new Vector2(star.Data.position.x, star.Data.position.y);
        for (var i = 0; i < lights.Length; i++)
        {
            lights[i].color = new Color32(star.Data.color[0], star.Data.color[1], star.Data.color[2], 255);
        }
    }

    public void Click()
    {
        Registry.profile.Data.current_solarsystem = gameObject.name;
        Registry.profile.Data.latest_solarSystem = gameObject.name;
        Registry.profile.Save();
        Star star = RiretrimUtility.GetStar(Registry.profile.Data.current_solarsystem);
        star.Data.visited = true;
        star.Data.visitTime = star.Data.visitTime.convertToJsonDateTime(DateTime.Now);
        SceneManager.LoadScene("SpaceMap");
    }

}
