using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ShadowCasterObject : MonoBehaviour
{
    //Objects with this Script will enable/disable, depending upon Option.ObjectShadows
    void Start()
    {
        if (gameObject.GetComponent<ShadowCaster2D>() != null)
        {
            gameObject.GetComponent<ShadowCaster2D>().enabled = Options.Data.ObjectShadows;
        }
    }
}