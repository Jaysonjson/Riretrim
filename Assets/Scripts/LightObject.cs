using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightObject : MonoBehaviour
{
    void Start()
    {
        if (gameObject.GetComponent<Light2D>() != null)
        {
            gameObject.GetComponent<Light2D>().enabled = Options.Lights;
        }
    }
}