using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Stars : MonoBehaviour
{
   public Star star;
   public TextMeshPro text;

   public Light2D[] lights;
   private void Start()
   {
        text.GetComponent<TextMeshPro>().text = star.Data.name + "\nLast Visited on: " + star.Data.visitTime.convertToDateTime().ToString("dd/M/yyyy hh:mm:ss");
        if (star.Data.visited)
        {
            text.GetComponent<TextMeshPro>().color = new Color32(0, 163, 14, 255);
        }
        else
        {
        text.GetComponent<TextMeshPro>().color = new Color32(163, 0, 0, 255);
        }
        name = star.Data.name;
        GetComponent<Orbit>().speed = star.Data.speed;
        GetComponent<SpriteRenderer>().color = new Color32(star.Data.color[0], star.Data.color[1], star.Data.color[2], 255);
        transform.position = new Vector2(star.Data.position_x, star.Data.position_y);
        for (var i = 0; i < lights.Length; i++)
        {
         lights[i].color = new Color32(star.Data.color[0], star.Data.color[1], star.Data.color[2], 255);
        }
   }
}
