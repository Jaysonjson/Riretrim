using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemObject : MonoBehaviour
{
    //Objects with this Script will enable/disable, depending upon Option.ParticleSystems
    void Start()
    {
        gameObject.SetActive(Options.ParticleSystems);
    }
}
