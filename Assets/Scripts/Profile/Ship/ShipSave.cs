using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ShipSave
{
    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Application.persistentDataPath + "/profiles/" + References.current_profile + "/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/profiles/" + References.current_profile + "/");
        }
        string path = Application.persistentDataPath + "/profiles/" + References.current_profile + "/ship.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        ShipData data = new ShipData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ShipData Load()
    {
        string path = Application.persistentDataPath + "/profiles/" + References.current_profile + "/ship.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ShipData data = formatter.Deserialize(stream) as ShipData;
            stream.Close();

            return data;
        }
        else
        {
            Ship.Save();
            return null;
        }
    }
}
