using UnityEngine;
public class ModdedShipMono : MonoBehaviour
{
    
    private void Start()
    {
        gameObject.name = Registry.profile.Ship.Data.body;
        ModdedShip moddedShip = ModdedShipUtility.FindShip(Registry.profile.Ship.Data.body, Mods.ships);
        GetComponent<ShipSprites>().Flight = moddedShip.sprite;
        GetComponent<ShipSprites>().Damaged = moddedShip.sprite;
        GetComponent<ShipSprites>().Idle = moddedShip.sprite;
        GetComponent<ShipSprites>().Special = moddedShip.sprite;
        GetComponent<ShipSprites>().Wing = moddedShip.sprite;
    }
}