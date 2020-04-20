using UnityEngine;

public class ShipWreckSpawner : MonoBehaviour
{
    public GameObject dummy;
    void Start()
    {
        for (int i = 1; i < 5; i++)
        {
           // GameObject shipwreck = Instantiate(dummy, gameObject.transform, false);
            GameObject shipwreck = Instantiate(dummy, gameObject.transform, false);
        }
        for (int i = 0; i < References.shipwrecks.Count; i++)
        {
            GameObject shipWreck = Instantiate(GameObject.Find(ShipWrecks.GetShipWreck(i).type), ShipWrecks.GetShipWreck(i).main.transform, false);
        }
    }   
}