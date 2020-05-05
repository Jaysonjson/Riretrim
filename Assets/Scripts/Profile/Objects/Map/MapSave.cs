using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class MapSave
{
    public static void save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Registry.profile.map_path))
        {
            Directory.CreateDirectory(Registry.profile.map_path);
        }
        string path = Registry.profile.map_path + "/mapdata.map";
        FileStream stream = new FileStream(path, FileMode.Create);

        MapData data = new MapData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static MapData load()
    {
        string path = Registry.profile.map_path + "/mapdata.map";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MapData data = formatter.Deserialize(stream) as MapData;
            stream.Close();

            return data;
        }
        else
        {
            Map.save();
            return load();
        }
    }
}
