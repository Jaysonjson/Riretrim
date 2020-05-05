using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class MoonSave
{
    public static void SaveNewMoon(string planet, Moon moon)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Registry.profile.map_path + "/planets/" + planet + "/moons/" + moon.name + "/"))
        {
            Directory.CreateDirectory(Registry.profile.map_path + "/planets/" + planet + "/moons/" + moon.name + "/");
        }
        string path = Registry.profile.map_path + "/planets/" + planet + "/moons/" + moon.name + "/data" + ".moon";
        FileStream stream = new FileStream(path, FileMode.Create);

        MoonData data = new MoonData(moon);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static MoonData LoadUsingName(string planet, string moon)
    {
        string path = Registry.profile.map_path + "/planets/" + planet + "/moons/" + moon + "/data" + ".moon";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MoonData data = formatter.Deserialize(stream) as MoonData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
