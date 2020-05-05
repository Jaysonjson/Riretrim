using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlanetSave
{
    public static void save(int index)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Registry.profile.map_path + "/planets/" + Planets.GetPlanet(index).getName() + "/"))
        {
            Directory.CreateDirectory(Registry.profile.map_path + "/planets/" + Planets.GetPlanet(index).getName() + "/");
        }
        string path = Registry.profile.map_path + "/planets/" + Planets.GetPlanet(index).getName() + "/data" + ".planet";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlanetData data = new PlanetData(index);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlanetData load(int index)
    {
        string path = Registry.profile.map_path + "/planets/" + Planets.GetPlanet(index).getName() + "/data" + ".planet";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlanetData data = formatter.Deserialize(stream) as PlanetData;
            stream.Close();

            return data;
        }
        else
        {
            Planets.GetPlanet(index).save(index);
            return load(index);
        }
    }
    public static PlanetData LoadUsingName(string name)
    {
        string path = Registry.profile.map_path + "/planets/" + name + "/data" + ".planet";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlanetData data = formatter.Deserialize(stream) as PlanetData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
