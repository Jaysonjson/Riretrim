using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ShadowCasterObject : MonoBehaviour
{
    void Start()
    {
        if (gameObject.GetComponent<ShadowCaster2D>() != null)
        {
            gameObject.GetComponent<ShadowCaster2D>().enabled = Options.ObjectShadows;
        }
    }
}