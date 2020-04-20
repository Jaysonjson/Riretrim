using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class OptionsSave
{
    public static void save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Application.persistentDataPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath);

        }
        string path = Application.persistentDataPath + "/settings";
        FileStream stream = new FileStream(path, FileMode.Create);

        OptionsData data = new OptionsData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static OptionsData load()
    {
        string path = Application.persistentDataPath + "/settings";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            OptionsData data = formatter.Deserialize(stream) as OptionsData;
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
