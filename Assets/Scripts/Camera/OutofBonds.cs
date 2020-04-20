using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBonds : MonoBehaviour
{
    void OnBecameInvisible()
    {
        if (gameObject.active)
        {
            Destroy(gameObject);
        }
    }
}
