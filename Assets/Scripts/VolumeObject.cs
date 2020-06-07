using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeObject : MonoBehaviour
{
   void Start()
    {
        gameObject.SetActive(Options.Data.PostProcessing);
    }
}
