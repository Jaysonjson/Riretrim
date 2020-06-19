using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfCamera : MonoBehaviour
{
    public bool activate = true;
    void OnBecameInvisible()
    {
        if (gameObject.activeSelf)
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
        if(gameObject.activeSelf && activate)
        {
            MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour c in comps)
            {
                c.enabled = true;
            }
        }
    }
}
