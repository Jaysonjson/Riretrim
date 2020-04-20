using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableParticlesystem : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(Options.particle_systems);  
    }
}
