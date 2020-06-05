using UnityEngine;

public class SpaceStations : MonoBehaviour
{
    public SpaceStation spaceStation;
    public Planet planet;
    private void Start()
    {
        name = spaceStation.Data.name;
        //transform.localScale = new Vector3((scale / planetObject.Data.scale) * 2, (scale / planetObject.Data.scale) * 2, 1);
    }
}
