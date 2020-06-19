/*using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ProfileSaveOld
{
    public static void save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Application.persistentDataPath + "/profiles/" + References.current_profile + "/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/profiles/" + References.current_profile + "/");

        }
        string path = Application.persistentDataPath + "/profiles/" + References.current_profile + "/data.pro";
        FileStream stream = new FileStream(path, FileMode.Create);

        ProfileData data = new ProfileData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ProfileData load()
    {
        string path = Application.persistentDataPath + "/profiles/" + References.current_profile + "/data.pro";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ProfileData data = formatter.Deserialize(stream) as ProfileData;
            stream.Close();

            return data;
        }
        else
        {
            Profile.save();
            return load();
        }
    }
}
*/