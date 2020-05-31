using UnityEngine;
public class MouseColor : MonoBehaviour
{
    public SpriteRenderer renderer;
    public GameObject arrow;
    private void Update()
    {
        Color c;
        Texture2D tex = renderer.sprite.texture; 
        c = tex.GetPixel((int)arrow.transform.position.x, (int)arrow.transform.position.y); 
        Debug.Log(c.r + "_" + c.g + "_" + c.b);
    }
}