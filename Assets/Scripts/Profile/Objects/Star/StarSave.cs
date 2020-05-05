using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class StarSave
{
    public static void save(int index)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + Stars.GetStar(index).sname + "/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + Stars.GetStar(index).sname + "/");
        }
        string path = Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + Stars.GetStar(index).sname + "/data.star";
        FileStream stream = new FileStream(path, FileMode.Create);

        StarData data = new StarData(Stars.GetStar(index));
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void saveNewstar(Star star)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + star.sname + "/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + star.sname + "/");
        }
        string path = Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + star.sname + "/data.star";
        FileStream stream = new FileStream(path, FileMode.Create);

        StarData data = new StarData(star);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static StarData load(int index)
    {
        string path = Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + Stars.GetStar(index).sname + "/data.star";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            StarData data = formatter.Deserialize(stream) as StarData;
            stream.Close();

            return data;
        }
        else
        {
            Stars.GetStar(index).Save(index);
            return load(index);
        }
    }

    public static StarData LoadUsingName(string name)
    {
        string path = Application.persistentDataPath + "/profiles/" + References.current_profile + "/" + Registry.profile.Data.current_galaxy + "/stars/" + name + "/data.star";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            StarData data = formatter.Deserialize(stream) as StarData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
