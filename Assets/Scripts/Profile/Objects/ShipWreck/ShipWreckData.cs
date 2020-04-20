[System.Serializable]
public class ShipWreckData
{
    public string name;
    public string type;
    public ShipWreckData(ShipWreck wreck)
    {
        name = wreck.name;
        type = wreck.type;
    }
}