using System;
using UnityEngine;

public class RedBlink : MonoBehaviour
{
   private byte alpha = 254;
   private bool decrease = false;
   private void Update()
   {
      SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      //byte alpha = (byte)spriteRenderer.color.a;
      if (alpha < 254 && !decrease)
      { 
         alpha += 1;
      }

      if (alpha > 253)
      {
         decrease = true;
      }
      if (decrease)
      {
         alpha -= 1;
      }

      if (alpha < 85)
      {
         decrease = false;
      }

      //spriteRenderer.color = new Color32((byte)spriteRenderer.color.r, (byte)spriteRenderer.color.g, (byte)spriteRenderer.color.b, alpha);
      spriteRenderer.color = new Color32(255, 36, 84, alpha);
   }
}
