using UnityEngine;
public class ModdedShipMono : MonoBehaviour
{

    private void Start()
    {
        gameObject.name = Registry.profile.Ship.Data.body;
        ModdedShip moddedShip = ModdedShipUtility.FindShip(Registry.profile.Ship.Data.body, Mods.ships);
        ShipSprites shipSprites = GetComponent<ShipSprites>();
        shipSprites.Flight = moddedShip.sprite;
        shipSprites.Damaged = moddedShip.sprite;
        shipSprites.Idle = moddedShip.sprite;
        shipSprites.Special = moddedShip.sprite;
        shipSprites.Wing = moddedShip.sprite;
    }
}