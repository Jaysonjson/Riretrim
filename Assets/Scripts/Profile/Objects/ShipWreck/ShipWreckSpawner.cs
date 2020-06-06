using System.Linq;
using UnityEngine;

public class ShipWreckSpawner : MonoBehaviour
{
    public GameObject dummy;
    void Start()
    {
        for (int i = 1; i < RiretrimUtility.GetStar(Registry.profile.Data.current_solarsystem).Data.shipWrecks.Count; i++)
        {
           // GameObject shipwreck = Instantiate(dummy, gameObject.transform, false);
            GameObject shipwreck = Instantiate(dummy, gameObject.transform, false);
            shipwreck.GetComponent<ShipWrecks>().shipWreck = RiretrimUtility.GetStar(Registry.profile.Data.current_solarsystem).Data.shipWrecks.ElementAt(i).Value;
            System.Random random = new System.Random();
            //float scale = (float)(random.Next(1, 3) + random.NextDouble());
            //shipwreck.transform.localScale = new Vector3(scale, scale, scale);
            shipwreck.transform.position = new Vector2(Random.Range(-175, 175) + 5, Random.Range(-75, 75) + 5);
        }
    }   
}