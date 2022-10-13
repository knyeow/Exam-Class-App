
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class SaveSystem
{

    public static void SaveData(Main main)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/Students.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        Data data = new Data(main);

        formatter.Serialize(stream, data);
        stream.Close();


    }
   

    public static Data LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Students.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(stream) as Data;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

}
