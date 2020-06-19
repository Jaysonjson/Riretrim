using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlanetSaveBackup
{
   /* public static void save(int index)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Profile.map_path + "/planets/" + Planets.GetPlanet(index).getName() + "/"))
        {
            Directory.CreateDirectory(Profile.map_path + "/planets/" + Planets.GetPlanet(index).getName() + "/");
        }
        string path = Profile.map_path + "/planets/" + Planets.GetPlanet(index).getName() + "/data" + ".pla";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlanetData data = new PlanetData(index);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlanetData load(int index)
    {
        string path = Profile.map_path + "/planets/" + Planets.GetPlanet(index).getName() + "/data" + ".pla";
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
    */
}
