public class SpaceStations
{
    public static SpaceStation AddSpaceStation(SpaceStation spaceStation)
    {
        spaceStation.index = References.spaceStations.Count;
        References.spaceStations.Add(spaceStation);
        return spaceStation;
    }

    public static SpaceStation GetSpaceStation(int index)
    {
        return References.spaceStations[index];
    }

}
