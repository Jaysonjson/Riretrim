using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ShipWreckSave
{
    public static void SaveNewShipWreck(ShipWreck shipWreck)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Profile.map_path + "/shipwrecks/" + shipWreck.name + "/"))
        {
            Directory.CreateDirectory(Profile.map_path + "/shipwrecks/" + shipWreck.name + "/");
        }
        string path = Profile.map_path + "/shipwrecks/" + shipWreck.name + "/data.shipwreck";
        FileStream stream = new FileStream(path, FileMode.Create);

        ShipWreckData data = new ShipWreckData(shipWreck);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ShipWreckData LoadUsingName(string shipWreck)
    {
        string path = Profile.map_path + "/shipwrecks/" + shipWreck + "/data.shipwreck";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ShipWreckData data = formatter.Deserialize(stream) as ShipWreckData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
