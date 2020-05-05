using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class MapOptionsSave
{
    public static void save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Registry.profile.profile_path))
        {
            Directory.CreateDirectory(Registry.profile.profile_path);

        }
        string path = Registry.profile.profile_path + "map_settings";
        FileStream stream = new FileStream(path, FileMode.Create);

        MapOptionsData data = new MapOptionsData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static MapOptionsData load()
    {
        string path = Registry.profile.profile_path + "map_settings";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MapOptionsData data = formatter.Deserialize(stream) as MapOptionsData;
            stream.Close();

            return data;
        }
        else
        {
            MapOptions.save();
            return load();
        }
    }
}