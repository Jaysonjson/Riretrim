using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class MapOptionsSave
{
    public static void save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Profile.profile_path))
        {
            Directory.CreateDirectory(Profile.profile_path);

        }
        string path = Profile.profile_path + "/map_settings";
        FileStream stream = new FileStream(path, FileMode.Create);

        MapOptionsData data = new MapOptionsData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static MapOptionsData load()
    {
        string path = Profile.profile_path + "/map_settings";
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
            Options.save();
            return load();
        }
    }
}