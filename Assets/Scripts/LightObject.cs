using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightObject : MonoBehaviour
{   
    //Objects with this Script will enable/disable, depending upon Option.Lights
    void Start()
    {
        if (gameObject.GetComponent<Light2D>() != null)
        {
            gameObject.GetComponent<Light2D>().enabled = Options.Lights;
        }
    }
}