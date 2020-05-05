using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GalaxySave
{
    public static void save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/");
        }
        string path = Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars.star";
        FileStream stream = new FileStream(path, FileMode.Create);

        GalaxyData data = new GalaxyData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GalaxyData load()
    {
        string path = Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars.star";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GalaxyData data = formatter.Deserialize(stream) as GalaxyData;
            stream.Close();

            return data;
        }
        else
        {
            Galaxy.save();
            return load();
        }
    }
}
