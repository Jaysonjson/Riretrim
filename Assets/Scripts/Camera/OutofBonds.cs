using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBonds : MonoBehaviour
{
    void OnBecameInvisible()
    {
        if (gameObject.activeSelf)
        {
            if (GetComponent<LootList>() != null)
            {
                GetComponent<LootList>().dropLoot = false;
            }
            Destroy(gameObject);
        }
    }
}
