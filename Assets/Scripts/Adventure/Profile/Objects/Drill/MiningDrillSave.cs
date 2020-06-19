using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class MiningDrillSave
{
    public static void SaveNewMiningDrill(string planet, MiningDrill miningDrill)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Registry.profile.map_path + "/planets/" + planet + "/drills/" + miningDrill.index + "/"))
        {
            Directory.CreateDirectory(Registry.profile.map_path + "/planets/" + planet + "/drills/" + miningDrill.index + "/");
        }
        string path = Registry.profile.map_path + "/planets/" + planet + "/drills/" + miningDrill.index + "/data" + ".drill";
        FileStream stream = new FileStream(path, FileMode.Create);

        MiningDrillData data = new MiningDrillData(miningDrill);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static MiningDrillData LoadUsingIndex(string planet, string miningDrill)
    {
        string path = Registry.profile.map_path + "/planets/" + planet + "/drills/" + miningDrill + "/data" + ".drill";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MiningDrillData data = formatter.Deserialize(stream) as MiningDrillData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
