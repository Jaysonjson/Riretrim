using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightObject : MonoBehaviour
{   
    //Objects with this Script will enable/disable, depending upon Option.Lights
    void Start()
    {
        if (gameObject.GetComponent<Light2D>() != null)
        {
            Light2D light = gameObject.GetComponent<Light2D>();
            light.enabled = Options.Data.Lights;
            if(Options.Data.PostProcessing)
            {
                light.intensity /= 1.5f;
            }
        }
    }
}