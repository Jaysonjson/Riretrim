using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SpaceStationSave
{
    public static void SaveNewSpaceStation(string planet, SpaceStation spaceStation)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Registry.profile.map_path + "/planets/" + planet + "/spacestations/" + spaceStation.name + "/"))
        {
            Directory.CreateDirectory(Registry.profile.map_path + "/planets/" + planet + "/spacestations/" + spaceStation.name + "/");
        }
        string path = Registry.profile.map_path + "/planets/" + planet + "/spacestations/" + spaceStation.name + "/data" + ".station";
        FileStream stream = new FileStream(path, FileMode.Create);

        SpaceStationData data = new SpaceStationData(spaceStation);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SpaceStationData LoadUsingName(string planet, string spaceStation)
    {
        string path = Registry.profile.map_path + "/planets/" + planet + "/spacestations/" + spaceStation + "/data" + ".station";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SpaceStationData data = formatter.Deserialize(stream) as SpaceStationData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
