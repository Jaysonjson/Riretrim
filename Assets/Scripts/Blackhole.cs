using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Blackhole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            if (other.GetComponent<SMPlayer>() != null) 
            { 
            other.GetComponent<SMPlayer>().blackhole = true;
            other.GetComponent<SMPlayer>().blackholeObject = gameObject;
                other.GetComponent<Orbit>().target = gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            if (other.GetComponent<SMPlayer>() != null)
            {
                other.GetComponent<SMPlayer>().blackhole = false;
            }
        }
    }
}