using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Blackhole : MonoBehaviour
{
    public SMPlayer SMPlayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            if (SMPlayer != null) 
            { 
                SMPlayer.blackhole = true;
                SMPlayer.blackholeObject = gameObject;
                other.GetComponent<Orbit>().target = gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            if (SMPlayer != null)
            {
                SMPlayer.blackhole = false;
            }
        }
    }
}