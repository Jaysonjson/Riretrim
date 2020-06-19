using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyscreenZoom : MonoBehaviour
{
    bool zoom = false;
    public Camera mainCamera;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(zoom)
            {
                mainCamera.orthographicSize *= 2;
                zoom = false;
            } else
            {
                mainCamera.orthographicSize /= 2;
                zoom = true;
            }
        }   
    }
}
