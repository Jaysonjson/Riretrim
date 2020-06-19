using System;
using System.IO;
using System.Reflection;
using UnityEngine;

public class Sprites : MonoBehaviour
{
    public Sprite MATERIALS_METAL;
    public Sprite MATERIALS_CRYSTAL;
    public Sprite MATERIALS_CARBON;
    public Sprite MATERIALS_GOLD;
    public Sprite MATERIALS_COAL;
    public Sprite MATERIALS_TITAN;
    public Sprite ASTEROID;
    public Sprite PLAYER;
    public Sprite FALLBACK;

    public void Start()
    {
        if (Options.Data.Texturepack != "Default")
        {
            setSprite(MATERIALS_METAL, "material_metal");
            setSprite(ASTEROID, "asteroid");
            setSprite(FALLBACK, "fallback");
        }

        /* for (var i = 0; i < this.GetType().GetFields().Length; i++)
        {
            FieldInfo field = this.GetType().GetFields()[i];
        }
        */
    }
    
    private void setSprite(Sprite sprite, string id)
    {
        if (Resources.Load<Sprite>(Options.Data.Texturepack + "/sprites/" + id + ".png") != null)
        {
            sprite = Resources.Load<Sprite>(Options.Data.Texturepack + "/sprites/" + id + ".png");
        }
    }
}
