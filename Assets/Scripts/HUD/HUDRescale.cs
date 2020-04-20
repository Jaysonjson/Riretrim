using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDRescale : MonoBehaviour
{
    public float adjustment;
    private float size;
    private void Start()
    {
        size = gameObject.transform.localScale.x;
    }

    public void onEnter()
    {
        gameObject.transform.localScale = new Vector3(size * adjustment, size * adjustment); 
    }

    public void onLeave()
    {
        gameObject.transform.localScale = new Vector3(size, size);

    }
}
