using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemObject : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(Options.ParticleSystems);
    }
}
