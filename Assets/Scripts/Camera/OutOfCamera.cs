using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfCamera : MonoBehaviour
{
    public bool activate = true;
    void OnBecameInvisible()
    {
        if (gameObject.active)
        {
            MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour c in comps)
            {
                c.enabled = false;
            }
            GetComponent<OutOfCamera>().enabled = true;
        }
    }
    private void OnBecameVisible()
    {
        if(gameObject.active && activate)
        {
            MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour c in comps)
            {
                c.enabled = true;
            }
        }
    }
}
